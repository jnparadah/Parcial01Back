using System;
using System.Collections.Generic;

namespace Parcial01Back.Models;

public partial class Comidum
{
    public int IdComida { get; set; }

    public string? Nombre { get; set; }

    public string? Tipo { get; set; }

    public int? Cantidad { get; set; }

    public int? IdMascota { get; set; }
}
