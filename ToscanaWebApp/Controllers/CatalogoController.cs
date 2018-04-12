using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToscanaWebApp.Models;

namespace ToscanaWebApp.Controllers
{
    public class CatalogoController : Controller
    {
        const string SessionKeyDate = "_Date";

        private readonly ToscanaBDContext _context;

        public CatalogoController(ToscanaBDContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var toscanaBDContext = _context.Producto.ToList();
            return View(toscanaBDContext.ToList());

        }



        public IActionResult Agrega()
        {
            
            CarritoCompra carritoCompra = new CarritoCompra { Cantidad = 20, IDProducto = 10 };
            HttpContext.Session.Set<CarritoCompra>(SessionKeyDate, carritoCompra);

            return RedirectToAction("Index");
        }

        
        public IActionResult Valida(int? id)
        {
            var date = HttpContext.Session.Get<CarritoCompra>(SessionKeyDate);

            return Content("Cantidad: "+ date.Cantidad + "id: " + date.IDProducto);
        }
    }



    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) :
                                  JsonConvert.DeserializeObject<T>(value);
        }
    }

}