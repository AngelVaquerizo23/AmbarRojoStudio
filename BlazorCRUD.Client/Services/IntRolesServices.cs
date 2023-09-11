using BlazorCRUD.Shared;

namespace BlazorCRUD.Client.Services
{
    public interface IntRolesServices
    {
        Task<List<RolesShared>> Lista();
    }
}
