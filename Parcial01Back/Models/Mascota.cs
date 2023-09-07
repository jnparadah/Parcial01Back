using System;
using System.Collections.Generic;

namespace Parcial01Back.Models;

public partial class Mascota
{
    public int IdMascota { get; set; }

    public string? Nombre { get; set; }

    public string? Especie { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public int? IdDuenio { get; set; }
}
