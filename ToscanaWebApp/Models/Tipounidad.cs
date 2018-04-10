using System;
using System.Collections.Generic;

namespace ToscanaWebApp.Models
{
    public partial class Tipounidad
    {
        public Tipounidad()
        {
            Producto = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string Unidadmetrica { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Producto> Producto { get; set; }
    }
}
