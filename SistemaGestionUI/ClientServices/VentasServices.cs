using SistemaGestionEntities;
using SistemaGestionUI.Components.Pages.Usuarios;

namespace SistemaGestionUI.ClientServices
{
    public class VentasServices
    {
        private readonly HttpClient _httpClient;

        public VentasServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Venta>> GetVentas()
        {
            return await _httpClient.GetFromJsonAsync<List<Venta>>("");

        }
        public async Task<Venta?> GetOneVenta(int id)
        {
            return await _httpClient.GetFromJsonAsync<Venta>($"{id}");
        }
        public async Task CreateVenta(Venta venta)
        {
            await _httpClient.PostAsJsonAsync("", venta);
        }

        public async Task UpdateVenta(int id, Venta venta)
        {
            await _httpClient.PutAsJsonAsync($"{id}", venta);
        }
        public async Task DeleteVenta(int id)
        {
            await _httpClient.DeleteAsync($"{id}");
        }
    }
}
