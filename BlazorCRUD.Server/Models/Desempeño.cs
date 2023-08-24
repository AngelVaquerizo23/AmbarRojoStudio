using System;
using System.Collections.Generic;

namespace BlazorCRUD.Server.Models;

public partial class Desempeño
{
    public int IdDesempeño { get; set; }

    public int Calificacion { get; set; }

    public string Observaciones { get; set; } = null!;

    public string IdIndicaciones { get; set; } = null!;
}
