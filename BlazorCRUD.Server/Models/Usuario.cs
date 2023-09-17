using System;
using System.Collections.Generic;

namespace BlazorCRUD.Server.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string StastusPersona { get; set; } = null!;

    public int IdPersona { get; set; }
}
