using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToscanaWebApp.Models;

namespace ToscanaWebApp.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ToscanaBDContext _context;

        public PedidoController(ToscanaBDContext context)
        {
            _context = context;
        }

        // GET: Pedido
        public async Task<IActionResult> Index()
        {
            return Ok();
        }

        // GET: Pedido/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            

            return View();
        }

        //// GET: Pedido/Create
        //public IActionResult Create()
        //{
        //    ViewData["Clienteid"] = new SelectList(_context.Cliente, "Id", "Direccion");
        //    return View();
        //}

        //// POST: Pedido/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Codigopedido,Clienteid,Estado,Direccion,Telefono,Celular,Total")] Pedidos pedidos)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(pedidos);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["Clienteid"] = new SelectList(_context.Cliente, "Id", "Direccion", pedidos.Clienteid);
        //    return View(pedidos);
        //}

        //// GET: Pedido/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var pedidos = await _context.Pedidos.SingleOrDefaultAsync(m => m.Id == id);
        //    if (pedidos == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["Clienteid"] = new SelectList(_context.Cliente, "Id", "Direccion", pedidos.Clienteid);
        //    return View(pedidos);
        //}

        //// POST: Pedido/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Codigopedido,Clienteid,Estado,Direccion,Telefono,Celular,Total")] Pedidos pedidos)
        //{
        //    if (id != pedidos.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(pedidos);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PedidosExists(pedidos.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["Clienteid"] = new SelectList(_context.Cliente, "Id", "Direccion", pedidos.Clienteid);
        //    return View(pedidos);
        //}

        //// GET: Pedido/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var pedidos = await _context.Pedidos
        //        .Include(p => p.Cliente)
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (pedidos == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(pedidos);
        //}

        //// POST: Pedido/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var pedidos = await _context.Pedidos.SingleOrDefaultAsync(m => m.Id == id);
        //    _context.Pedidos.Remove(pedidos);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool PedidosExists(int id)
        {
            return true;
        }
    }
}
