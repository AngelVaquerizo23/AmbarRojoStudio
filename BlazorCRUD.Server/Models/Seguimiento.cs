using System;
using System.Collections.Generic;

namespace BlazorCRUD.Server.Models;

public partial class Seguimiento
{
    public int IdSeguimiento { get; set; }

    public int Porsentaje { get; set; }

    public string Estado { get; set; } = null!;

    public int IdProyecto { get; set; }
}
