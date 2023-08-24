using System;
using System.Collections.Generic;

namespace BlazorCRUD.Server.Models;

public partial class Proyecto
{
    public int IdProyecto { get; set; }

    public string NombreProyecto { get; set; } = null!;

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFinal { get; set; }
}
