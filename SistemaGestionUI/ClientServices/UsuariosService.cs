using Microsoft.AspNetCore.Components.Authorization;
using SistemaGestionEntities;
using SistemaGestionUI.Components.Pages.ProductosVendidos;
using SistemaGestionWebApi.Dto;
using System.Security.Claims;


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
        
        public async Task<ResponseLoginDto> login(AuthDto dato)
        {
            // Enviar solicitud HTTP POST con el objeto 'dato' en formato JSON
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("login", dato);

            // Verificar si la respuesta fue exitosa
            if (response.IsSuccessStatusCode)
            {
                // Leer el contenido de la respuesta y deserializarlo en un ResponseLoginDto
                var resp = await response.Content.ReadFromJsonAsync<ResponseLoginDto>();
                return resp;
            }
            else
            {
                // Manejar el caso donde la respuesta no sea exitosa
                throw new Exception($"Error al hacer login: {response.ReasonPhrase}");
            }
        }

    }
}
