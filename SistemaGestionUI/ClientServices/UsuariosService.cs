
using SistemaGestionEntities;
using SistemaGestionUI.Components.Pages.ProductosVendidos;

namespace SistemaGestionUI.ClientServices
{
    public class UsuariosService
    {
        private readonly HttpClient _httpClient;

        public UsuariosService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            return await _httpClient.GetFromJsonAsync<List<Usuario>>("");
        }
        public async Task<Usuario?> GetOneUsuario(int id)
        {
            return await _httpClient.GetFromJsonAsync<Usuario>($"{id}");
        }
        public async Task CreateUsuario(Usuario usuario)
        {
            await _httpClient.PostAsJsonAsync("", usuario);
        }

        public async Task UpdateUsuario(int id, Usuario usuario)
        {
            await _httpClient.PutAsJsonAsync($"{id}", usuario);
        }
        public async Task DeleteUsuario(int id)
        {
            await _httpClient.DeleteAsync($"{id}");
        }

    }
}
