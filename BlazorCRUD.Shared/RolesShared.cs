namespace BlazorCRUD.Shared
{
    public class RolesShared
    {
        public int IdRoles { get; set; }

        public string Rol { get; set; } = null!;

       public static implicit operator string(RolesShared v)
       {
           throw new NotImplementedException();
       }
    }
}
