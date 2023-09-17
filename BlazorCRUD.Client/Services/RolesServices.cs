using BlazorCRUD.Shared;
using System.Net.Http.Json;

namespace BlazorCRUD.Client.Services
{
    public class RolesServices : IRolesServices
    {
        private readonly HttpClient _http;

        public RolesServices(HttpClient http) 
        {
            _http = http;
        }

        public async Task<List<RolesShared>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<RolesShared>>>("api/Roles/Lista");

            if (result!.EsCorrecto)
                return result.Valor!;
            
            else
                throw new Exception(result.Mensaje);
        }
    }
}