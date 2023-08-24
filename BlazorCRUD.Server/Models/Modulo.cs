using System;
using System.Collections.Generic;

namespace BlazorCRUD.Server.Models;

public partial class Modulo
{
    public int IdModulo { get; set; }

    public string NombreModulo { get; set; } = null!;

    public int IdProyecto { get; set; }

    public int IdSeguimiento { get; set; }
}
