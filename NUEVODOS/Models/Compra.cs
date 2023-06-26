using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NUEVODOS.Models
{
    public partial class Compra
    {
        [Key]
        public int Idcompra { get; set; }
        public DateTime? Fechacompra { get; set; }
        public int Preciocompra { get; set; }
        public string Mpcompra { get; set; } = null!;
        public string? Limitacionescompra { get; set; }
        public string Ciudadcompra { get; set; } = null!;
        public int Spcompra { get; set; }
        public string Placacompra { get; set; } = null!;

        public virtual Vehiculo? PlacaC { get; set; } = null!;
    }
}
