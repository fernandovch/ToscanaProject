using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToscanaWebApp.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ToscanaWebApp.Extensions;

namespace ToscanaWebApp.Controllers
{
    public class CatalogoController : Controller
    {

        
        private readonly ToscanaBDContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CatalogoController(ToscanaBDContext context, IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
            _context = context;
        }


        public IActionResult Index()
        {
            var toscanaBDContext = _context.Producto.ToList();
            return View(toscanaBDContext.ToList());

        }



        public IActionResult Agrega(int? Id, int? Cantidad)
        {
            Dictionary<string, string> _Cargamento = new Dictionary<string, string>();

            int IDP = Id.HasValue == true ? Id.Value : 0;
            int Cant = Cantidad.HasValue == true ? Cantidad.Value : 0;

            if (TempData["cargamento"] != null)
            {
                _Cargamento = TempDataExtension.Get<Dictionary<string, string>>(TempData, "cargamento");
                _Cargamento.Add(IDP.ToString(), Cant.ToString());
            }
            else
            {
                _Cargamento.Add(IDP.ToString(), Cant.ToString());
            }

            TempDataExtension.Put<Dictionary<string, string>>(TempData, "cargamento", _Cargamento);

            return RedirectToAction("Index");
        }

        
        public IActionResult Valida()
        {
            

            return RedirectToAction("Index"); ;
        }


       


    }


   

}