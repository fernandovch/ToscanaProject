using System;
using System.Collections.Generic;

namespace ToscanaWebApp.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Detallepedido = new HashSet<Detallepedido>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Familiaid { get; set; }
        public int Categoriaid { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }
        public string Gravado { get; set; }
        public bool? Activo { get; set; }
        public DateTime? Fechacreacion { get; set; }
        public DateTime? Fechamodifica { get; set; }

        public ICollection<Detallepedido> Detallepedido { get; set; }
    }
}
