using BlazorCRUD.Shared;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace BlazorCRUD.Client.Services
{
    public class PersonaServices : IntPersonaServices
    {
        private readonly HttpClient _http;

        public PersonaServices(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<PersonaShared>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<PersonaShared>>>("api/Persona/Lista");

            if (result!.EsCorrecto)
                return result.Valor;

            else
                throw new Exception(result.Mensaje);
        }

        public async Task<PersonaShared> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<PersonaShared>>("$api/Persona/Buscar/{id}");

            if (result!.EsCorrecto)
                return result.Valor;

            else
                throw new Exception(result.Mensaje);
        }

        public async Task<int> Guardar(PersonaShared persona)
        {
            var result = await _http.PostAsJsonAsync("api/Persona/Guardar", persona);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor;

            else
                throw new Exception(response.Mensaje);
        }

        public async Task<int> Editar(PersonaShared persona)
        {
            var result = await _http.PutAsJsonAsync("$api/Persona/Editar/{persona.Id}", persona);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor;

            else
                throw new Exception(response.Mensaje);
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync("$api/Persona/Eliminar/{Id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.EsCorrecto;

            else
                throw new Exception(response.Mensaje);
        }
    }
}