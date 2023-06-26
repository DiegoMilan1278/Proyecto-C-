using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NUEVODOS.Models
{
    public partial class Venta
    {
        [Key]
        public int Idventa { get; set; }
        public DateTime? Fechaventa { get; set; }
        public int Precioventa { get; set; }
        public string Mpventa { get; set; } = null!;
        public string? Limitacionesventa { get; set; }
        public string Ciudadventa { get; set; } = null!;
        public int Spventa { get; set; }
        public string Placaventa { get; set; } = null!;

        public virtual Vehiculo? PlacaV { get; set; } = null!;
    }
}
