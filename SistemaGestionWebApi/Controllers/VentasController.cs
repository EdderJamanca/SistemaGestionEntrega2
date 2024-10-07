using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness.Services;
using SistemaGestionEntities;

namespace SistemaGestionWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController: ControllerBase
    {
        private readonly ILogger<VentasController> _logger;
        private readonly VentasService _ventasService;
        public VentasController(ILogger<VentasController> logger, VentasService ventasService)
        {
            _logger = logger;
            _ventasService = ventasService;
        }

        [HttpGet(Name = "Get Ventas")]
        public ActionResult<List<Venta>> GetVentas()
        {
            return _ventasService.GetVentas();
        }
        [HttpGet("{id}")]
        public ActionResult<Venta> GetOneVenta([FromRoute(Name = "id")] int id)
        {
            _logger.LogInformation("Consultando pro el producto con id {id}", id);
            var ventas = _ventasService.GetOneVenta(id);
            if(ventas == null)
            {
                return NotFound();
            }
            return ventas;
        }
        [HttpPost]
        public ActionResult<Venta> CreateVenta([FromBody] Venta venta)
        {
            var ventaCreado =   _ventasService.CreateVenta(venta);
            return CreatedAtAction(nameof(GetOneVenta), new { id = ventaCreado.Id }, ventaCreado);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateVenta([FromRoute(Name = "id")] int id, [FromBody] Venta venta)
        {
            _ventasService.UpdateVenta(id,venta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteVenta([FromRoute(Name = "id")] int id)
        {
             _ventasService.DeleteVenta(id);
            return NoContent();
        }
    }
}
