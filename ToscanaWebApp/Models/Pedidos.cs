using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToscanaWebApp.Models
{
    public partial class Pedidos
    {
        public Pedidos()
        {
            Detallepedido = new HashSet<Detallepedido>();
        }

        public int Id { get; set; }
        [Display(Name ="Codigo")]
        public string Codigopedido { get; set; }
        public int Clienteid { get; set; }
        public string Estado { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public decimal Total { get; set; }

        public Cliente Cliente { get; set; }
        public ICollection<Detallepedido> Detallepedido { get; set; }
    }
}
