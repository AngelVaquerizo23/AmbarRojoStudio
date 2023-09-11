using System;
using System.Collections.Generic;

namespace BlazorCRUD.Server.Models;

public partial class Persona
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string WhatsApp { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string IdRoles { get; set; } = null!;
    public DateTime FechaRegistro {get; set;}
    public virtual Role IdRolesNavigation { get; set; } = null!;
}