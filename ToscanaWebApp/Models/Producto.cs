using System;
using System.Collections.Generic;

namespace ToscanaWebApp.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Detallepedido = new HashSet<Detallepedido>();
            Inventariohistorico = new HashSet<Inventariohistorico>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidadid { get; set; }
        public int Categoriaid { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }
        public decimal Impuestoventas { get; set; }
        public decimal Impuestovarios { get; set; }
        public string Gravado { get; set; }

        public Tipounidad CantidadNavigation { get; set; }
        public Categoriaproducto Categoria { get; set; }
        public ICollection<Detallepedido> Detallepedido { get; set; }
        public ICollection<Inventariohistorico> Inventariohistorico { get; set; }
    }
}
