using System;
using System.Collections.Generic;

namespace ToscanaWebApp.Models
{
    public partial class Detallepedido
    {
        public int Id { get; set; }
        public int Pedidoid { get; set; }
        public int Productoid { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public bool? Generado { get; set; }

        public Producto Producto { get; set; }
    }
}
