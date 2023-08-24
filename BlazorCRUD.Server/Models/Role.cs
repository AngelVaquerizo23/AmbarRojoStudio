using System;
using System.Collections.Generic;

namespace BlazorCRUD.Server.Models;

public partial class Role
{
    public int IdRoles { get; set; }

    public string Rol { get; set; } = null!;

    public virtual ICollection<Persona> Personas { get; } = new List<Persona>();
}
