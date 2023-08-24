using System;
using System.Collections.Generic;

namespace BlazorCRUD.Server.Models;

public partial class Persona
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public int Telefono { get; set; }

    public int WhatsApp { get; set; }

    public string Correo { get; set; } = null!;

    public string IdRoles { get; set; } = null!;

    public virtual Role IdRolesNavigation { get; set; } = null!;
}