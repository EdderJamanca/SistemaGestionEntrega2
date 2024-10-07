
using SistemaGestionEntities;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;

namespace SistemaGestionUI.ClientServices
{
    public class ProductosService
    {
        private readonly HttpClient _httpClient;

        public ProductosService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Producto>?> GetProducts()
        {
            return await _httpClient.GetFromJsonAsync<List<Producto>>("");
        }
        //public async Task<List<Producto>?> GetProductosFriltro(string filtro)
        //{
        //    return await _httpClient.GetFromJsonAsync<List<Producto>>(
        //   QueryHelpers.AddQueryString("", new Dictionary<string, string>() { { "filtro", filtro } }));
        //}
        public async Task<Producto?> GetOneProducto(int id)
        {
            return await _httpClient.GetFromJsonAsync<Producto>($"{id}");
        }
        public async Task CreateProducto(Producto producto)
        {
            await _httpClient.PostAsJsonAsync("", producto);
        }

        public async Task UpdateProducto(int id, Producto producto)
        {
            await _httpClient.PutAsJsonAsync($"{id}", producto);

        }
        public async Task DeleteProducto(int id)
        {
            await _httpClient.DeleteAsync($"{id}");

        }
    }
}
