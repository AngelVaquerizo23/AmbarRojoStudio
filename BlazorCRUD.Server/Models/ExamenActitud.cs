using System;
using System.Collections.Generic;

namespace BlazorCRUD.Server.Models;

public partial class ExamenActitud
{
    public int IdExamenAc { get; set; }

    public string Examen { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }
}
