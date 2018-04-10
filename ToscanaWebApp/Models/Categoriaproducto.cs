using System;
using System.Collections.Generic;

namespace ToscanaWebApp.Models
{
    public partial class Categoriaproducto
    {
        public Categoriaproducto()
        {
            Producto = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string Categoria { get; set; }

        public ICollection<Producto> Producto { get; set; }
    }
}
