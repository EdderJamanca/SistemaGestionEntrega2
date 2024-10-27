
using SistemaGestionEntities;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Authorization;

namespace SistemaGestionUI.ClientServices
{
    public class ProductosService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;
        public ProductosService(HttpClient httpClient, AuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
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
