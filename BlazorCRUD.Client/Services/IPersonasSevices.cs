using BlazorCRUD.Shared;

namespace BlazorCRUD.Client.Services
{
    public interface IPersonasSevices
    {
        Task<List<PersonasShared>> Lista();
        Task<PersonasShared> Buscar(int id);
        Task<int> Guardar(PersonasShared persona);
        Task<int> Editar(PersonasShared persona);
        Task<bool> Eliminar(int id);
    }
}
