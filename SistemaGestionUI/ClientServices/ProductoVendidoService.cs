
using SistemaGestionEntities;
using SistemaGestionUI.Components.Pages.Productos;

namespace SistemaGestionUI.ClientServices
{
    public class ProductoVendidoService
    {
        private readonly HttpClient _httpClient;

        public ProductoVendidoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductoVendido>> GetProductsVendido()
        {
            return await _httpClient.GetFromJsonAsync<List<ProductoVendido>>("");

        }
        public async Task<ProductoVendido?> GetOneProductoVendido(int id)
        {
            return await _httpClient.GetFromJsonAsync<ProductoVendido>($"{id}");
        }
        public async Task CreateProductoVendido(ProductoVendido productovendido)
        {
            await _httpClient.PostAsJsonAsync("", productovendido);
        }

        public async Task UpdateProductoVendido(int id, ProductoVendido productovendido)
        {
            await _httpClient.PutAsJsonAsync($"{id}", productovendido);
        }
        public async Task DeleteProductoVendido(int id)
        {
            await _httpClient.DeleteAsync($"{id}");
        }
    }
}
