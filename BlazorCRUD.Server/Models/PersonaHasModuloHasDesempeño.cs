using System;
using System.Collections.Generic;

namespace BlazorCRUD.Server.Models;

public partial class PersonaHasModuloHasDesempeño
{
    public int Id { get; set; }

    public int IdPersona { get; set; }

    public int IdModulo { get; set; }

    public int IdDesempeño { get; set; }

    public string Area { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }
}
