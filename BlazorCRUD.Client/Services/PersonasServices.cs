using BlazorCRUD.Shared;
using System.Net.Http.Json;

namespace BlazorCRUD.Client.Services
{
    public class PersonasServices : IPersonasSevices
    {
        private readonly HttpClient _http;

        public PersonasServices(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<PersonasShared>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<PersonasShared>>>("api/Persona/Lista");

            if (result!.EsCorrecto)
                return result.Valor!;

            else
                throw new Exception(result.Mensaje);
        }

        public async Task<PersonasShared> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<PersonasShared>>($"api/Persona/Buscar/{id}");

            if (result!.EsCorrecto)
                return result.Valor!;

            else
                throw new Exception(result.Mensaje);
        }

        public async Task<int> Guardar(PersonasShared persona)
        {
            var result = await _http.PostAsJsonAsync("api/Persona/Guardar", persona);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;

            else
                throw new Exception(response.Mensaje);
        }

        public async Task<int> Editar(PersonasShared persona)
        {
            var result = await _http.PutAsJsonAsync($"api/Persona/Editar/{persona.Id}",persona);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;

            else
                throw new Exception(response.Mensaje);
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/Persona/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.EsCorrecto!;

            else
                throw new Exception(response.Mensaje);
        }

    }
}