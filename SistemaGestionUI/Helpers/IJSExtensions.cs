using Microsoft.JSInterop;

namespace SistemaGestionUI.Helpers
{
    public class IJSExtensions
    {
        private readonly IJSRuntime js;

        public IJSExtensions(IJSRuntime js)
        {
            this.js = js;
        }

        public ValueTask<object> SetInLocalStorage(string key, string content)
        {
            return js.InvokeAsync<object>("localStorage.setItem", key, content);
        }

        public async ValueTask<string> GetFromLocalStorage(string key)
        {
            string token =await js.InvokeAsync<string>("localStorage.getItem", key);
            return token;
        }

        public ValueTask<object> RemoveItem(string key)
        {
            return js.InvokeAsync<object>("localStorage.removeItem", key);
        }
    }
}
