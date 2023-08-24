using System;
using System.Collections.Generic;

namespace BlazorCRUD.Server.Models;

public partial class DocumentacionPersonal
{
    public int IdDoc { get; set; }

    public string Infomarcion { get; set; } = null!;

    public byte[] Cv { get; set; } = null!;

    public string Nivel { get; set; } = null!;

    public int IdPersona { get; set; }

    public int IdExamenAp { get; set; }

    public int IdExaxmenAc { get; set; }

    public int IdIngles { get; set; }
}
