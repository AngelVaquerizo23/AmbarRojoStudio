using System;
using System.Collections.Generic;

namespace BlazorCRUD.Server.Models;

public partial class IndicadoresDesempeño
{
    public int IdIndicaciones { get; set; }

    public string Descripcion { get; set; } = null!;
}
