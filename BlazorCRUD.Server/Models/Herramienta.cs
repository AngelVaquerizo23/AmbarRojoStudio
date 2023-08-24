using System;
using System.Collections.Generic;

namespace BlazorCRUD.Server.Models;

public partial class Herramienta
{
    public int IdHerramienta { get; set; }

    public string Nombre { get; set; } = null!;
}
