using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness.Services;
using SistemaGestionEntities;

namespace SistemaGestionWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ILogger<UsuariosController> _logger;
        private readonly UsuariosService _usuariosService;
        public UsuariosController(ILogger<UsuariosController> logger, UsuariosService usuariosService)
        {
            _logger = logger;
            _usuariosService = usuariosService;
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
        [HttpPost]
        public ActionResult<Usuario> CreateUsuario([FromBody]  Usuario usuario)
        {
            var usuarioCreado = _usuariosService.CreateUsuario(usuario);

            return CreatedAtAction(nameof(GetUsuarios), new { id = usuarioCreado.Id }, usuario);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateUsuario([FromRoute(Name = "id")] int id,[FromBody] Usuario usuario)
        {
            _usuariosService.UpdateUsuario(id,usuario);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteUsuario([FromRoute(Name = "id")] int id)
        {
            _usuariosService.DeleteUsuario(id);
            return NoContent();
        }
    }
}
