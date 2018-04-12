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
        private readonly ToscanaBDContext _context;

        public CatalogoController(ToscanaBDContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var toscanaBDContext = _context.Producto.ToList();
            return View( toscanaBDContext.ToList());
            
        }

        
        
        public IActionResult Agrega()
        {
            return RedirectToAction("Index");
        }
    }
}