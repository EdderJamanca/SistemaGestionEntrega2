using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness.Services;
using SistemaGestionEntities;

namespace SistemaGestionWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductosVendidosController : ControllerBase
    {
        private readonly ILogger<ProductosVendidosController> _logger;
        private readonly IProductosVendidosService _productosVendidosService;
        public ProductosVendidosController(ILogger<ProductosVendidosController> logger, IProductosVendidosService productosVendidosService)
        {
            _logger = logger;
            _productosVendidosService = productosVendidosService;
        }

        [HttpGet(Name = "Get Productos Vendidos")]
        public ActionResult<List<ProductoVendido>> GetProductsVendido()
        {
            return _productosVendidosService.GetProductsVendido();
        }
        [HttpGet("{id}")]
        public ActionResult<ProductoVendido> GetOneProductoVendido([FromRoute(Name = "id")]  int id)
        {
            return _productosVendidosService.GetOneProductoVendido(id);
        }
        [HttpGet("detalle/{idventa:int}")]
        public ActionResult<List<ProductoVendido>> ObtenerProductosVendidos(int idventa)
        {
            return  _productosVendidosService.ObtenerProductosVendidos(idventa);
        }
        [HttpPost]
        public ActionResult<ProductoVendido> CreateProductoVendido([FromBody]  ProductoVendido productovendido)
        {
            var productovendidoCreado = _productosVendidosService.CreateProductoVendido(productovendido);

            return CreatedAtAction(nameof(GetOneProductoVendido), new { id = productovendidoCreado.Id }, productovendido);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateProductoVendido([FromRoute(Name = "id")] int id, [FromBody]  ProductoVendido productovendido)
        {
            _productosVendidosService.UpdateProductoVendido(id,productovendido);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteProductoVendido([FromRoute(Name = "id")] int id)
        {
            _productosVendidosService.DeleteProductoVendido(id);
            return NoContent();
        }
    }
}
