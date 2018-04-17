using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToscanaWebApp.Models
{

    public class CarritoCompra
    {


        public Dictionary<string, string> Cargamento { get; set; }

        public CarritoCompra()
        {
            Cargamento = new Dictionary<string, string>() { { "", "" } };
        }
    }
}
