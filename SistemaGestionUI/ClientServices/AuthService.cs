using SistemaGestionUI.Helpers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
namespace SistemaGestionUI.ClientServices
{
    public interface ILoginServices
    {
        Task Login(string token);
        Task Logout();
    }
    public class AuthService : AuthenticationStateProvider, ILoginServices
    {
        
        public static readonly string TOKENKEY = "TOKENKEY";
        private readonly IJSExtensions js;
        private readonly HttpClient httpClient;
        private AuthenticationState anonimo => new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        public AuthService(IJSRuntime _js, HttpClient httpClient)
        {
            this.httpClient = httpClient;
            js = new IJSExtensions(_js);
        }
        public async Task Login(string token)
        {
            await js.RemoveItem(TOKENKEY);
            await js.SetInLocalStorage(TOKENKEY, token);
            var authState = BuildAuthenticationState(token);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }
        public async Task Logout()
        {
            httpClient.DefaultRequestHeaders.Authorization = null;
            await js.RemoveItem(TOKENKEY);
            NotifyAuthenticationStateChanged(Task.FromResult(anonimo));
        }
        public  override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                if (js == null)
                {
                    // Si estamos en prerenderizado, retornamos un estado anónimo provisional
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                }
                var token = await js.GetFromLocalStorage(TOKENKEY);

                if (string.IsNullOrEmpty(token))
                {
                    return anonimo;
                }

                return BuildAuthenticationState(token);
            }catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAuthenticationStateAsync: {ex.Message}");
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
        }

        public async Task<string> GetTokenAsync()
        {
            try
            {

                if (js == null || (js as IJSInProcessRuntime) == null)
                {
                    // Devuelve null o un valor predeterminado si estamos en prerenderizado
                    return null;
                }

                return await js.GetFromLocalStorage(TOKENKEY); 
            }
            catch(Exception ex)
            {
                return "";
            }
        }

        private AuthenticationState BuildAuthenticationState(string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt")));
        }
        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            return claims;
        }
        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
