using System;
using System.Collections.Generic;

namespace BlazorCRUD.Server.Models;

public partial class ExamenAptitud
{
    public int IdExamenAp { get; set; }

    public string Examen { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }
}
