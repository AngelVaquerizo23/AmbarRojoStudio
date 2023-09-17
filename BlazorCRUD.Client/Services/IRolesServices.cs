using BlazorCRUD.Shared;

namespace BlazorCRUD.Client.Services
{
    public interface IRolesServices
    {
        Task<List<RolesShared>> Lista();
    }
}
