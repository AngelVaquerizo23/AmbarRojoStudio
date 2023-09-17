using System;
using System.Collections.Generic;

namespace BlazorCRUD.Server.Models;

public partial class Estancium
{
    public string Descripcion { get; set; } = null!;

    public DateTime FechaDeInicio { get; set; }

    public DateTime FechaFinal { get; set; }

    public int IdPersona { get; set; }
}
