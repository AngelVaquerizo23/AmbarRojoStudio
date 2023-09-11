using BlazorCRUD.Shared;

namespace BlazorCRUD.Client.Services
{
    public interface IntPersonaServices
    {
        Task<List<PersonaShared>> Lista();
        Task<PersonaShared> Buscar(int id);
        Task<int> Guardar(PersonaShared persona);
        Task<int> Editar(PersonaShared persona);
        Task<bool> Eliminar(int id);
    }
}
