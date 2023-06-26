using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NUEVODOS.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Compras = new HashSet<Compra>();
            Venta = new HashSet<Venta>();
        }

        [Key]
        public string Placa { get; set; } = null!;
        public string Vehiculo1 { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public int Modelo { get; set; }
        public string Capacidad { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string Servicio { get; set; } = null!;
        public string Linea { get; set; } = null!;
        public string Motor { get; set; } = null!;
        public string Chasis { get; set; } = null!;
        public string Serie { get; set; } = null!;
        public string Empresa { get; set; } = null!;
        public string Matricula { get; set; } = null!;
        public string Kilometraje { get; set; } = null!;
        public string Cilindraje { get; set; } = null!;
        public string Combustible { get; set; } = null!;
        public string Traccion { get; set; } = null!;
        public string Soat { get; set; } = null!;
        public string Tecnomecanica { get; set; } = null!;
        public string Correadentada { get; set; } = null!;

        public virtual ICollection<Compra> Compras { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
