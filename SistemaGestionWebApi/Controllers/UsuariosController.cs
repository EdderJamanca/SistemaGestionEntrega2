using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SistemaGestionBussiness.Services;
using SistemaGestionEntities;
using SistemaGestionWebApi.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SistemaGestionWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsuariosController : ControllerBase
    {
        private readonly ILogger<UsuariosController> _logger;
        private readonly IUsuariosService _usuariosService;
        private readonly IConfiguration _configuration;
        public UsuariosController(ILogger<UsuariosController> logger, IUsuariosService usuariosService, IConfiguration configuration)
        {
            _logger = logger;
            _usuariosService = usuariosService;
            _configuration = configuration;
        }

        [HttpGet(Name = "Get Usuarios")]
        public ActionResult<List<Usuario>> GetUsuarios()
        {
            return _usuariosService.GetUsuarios();
        }
        [HttpGet("{id}")]
        public ActionResult<Usuario> GetOneUsuario([FromRoute(Name = "id")] int id)
        {
            _logger.LogInformation("Consultando por el producto con id {id}", id);
            var usuario = _usuariosService.GetOneUsuario(id);
            if (usuario is null)
            {
                return NotFound();
            }
            return usuario;
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<Usuario> CreateUsuario([FromBody] Usuario usuario)
        {
            var usuarioCreado = _usuariosService.CreateUsuario(usuario);

            return CreatedAtAction(nameof(GetUsuarios), new { id = usuarioCreado.Id }, usuario);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateUsuario([FromRoute(Name = "id")] int id, [FromBody] Usuario usuario)
        {
            _usuariosService.UpdateUsuario(id, usuario);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteUsuario([FromRoute(Name = "id")] int id)
        {
            _usuariosService.DeleteUsuario(id);
            return NoContent();
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async  Task<IActionResult> Login([FromBody] AuthDto dato)
        {
           Usuario? respueta = await _usuariosService.Login(dato.Email, dato.Password);
            var token = string.Empty;
            if (respueta != null)
            {
                try
                {
                    // Generar el token JWT
                    token = GenerarJwtToken(respueta);
                }
                catch (Exception ex)
                {
                    // Si ocurre algún error en la generación del token
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al generar el token" });
                }
            } else
            {
                return Unauthorized(new { message = "Usuario o contraseña incorrecta" });
            }

            ResponseLoginDto resp = new ResponseLoginDto()
            {
                token = token,
            };
            return Ok(resp);
        }

        private string GenerarJwtToken(Usuario usuario)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];
            //var issuer = jwtSettings["Issuer"];
            //var audience = jwtSettings["Audience"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, usuario.Mail),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role,"1"),
            new Claim(ClaimTypes.Actor, usuario.Nombre)
        };

                //issuer,
                //audience,
            var token = new JwtSecurityToken("","",
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
