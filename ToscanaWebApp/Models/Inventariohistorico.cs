using System;
using System.Collections.Generic;

namespace ToscanaWebApp.Models
{
    public partial class Inventariohistorico
    {
        public int Indice { get; set; }
        public int Productoid { get; set; }
        public int Cantidadactual { get; set; }
        public int Cantidadprevia { get; set; }
    }
}
