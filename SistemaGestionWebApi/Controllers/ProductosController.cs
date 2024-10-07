using SistemaGestionBussiness.Services;
using SistemaGestionEntities;
using Microsoft.AspNetCore.Mvc;

namespace SistemaGestionWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController: ControllerBase
    {
        private readonly ILogger<ProductosController> _logger;
        private readonly ProductosService _productosService;
        public ProductosController(ILogger<ProductosController> logger, ProductosService productosService)
        {
            _logger = logger;
            _productosService = productosService;
        }

        [HttpGet(Name = "Get Productos")]
        public ActionResult<List<Producto>> GetProductos() {
   
                return _productosService.GetProducts();
      
        }
        [HttpGet("{id}")]
        public ActionResult<Producto?> GetOneProducto([FromRoute(Name = "id")]  int id)
        {
            _logger.LogInformation("Consultando por el producto con id {id}", id);
            var producto = _productosService.GetOneProducto(id);
            if (producto is null)
            {
                return NotFound();
            }
            return producto;
        }
        [HttpPost]
        public ActionResult<Producto> CreateProducto([FromBody]  Producto producto)
        {
            var productoCreado = _productosService.CreateProducto(producto);
            return CreatedAtAction(nameof(GetOneProducto), new { id = productoCreado.Id }, producto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProducto([FromRoute(Name = "id")] int id, [FromBody] Producto producto)
        {
            _productosService.UpdateProducto(id,producto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteProducto([FromRoute(Name = "id")]  int id)
        {
            _productosService.DeleteProducto(id);
            return NoContent();
        }
    }
}
