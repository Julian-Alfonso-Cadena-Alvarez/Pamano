using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pamano.Core.Domain;
using Pamano.Infrastructure.Data;

namespace Pamano.Web.Controllers
{
    public class OrdenDeVentasController : Controller
    {
        private readonly PamanoDbContext _context;

        public OrdenDeVentasController(PamanoDbContext context)
        {
            _context = context;
        }

        // GET: OrdenDeVentas
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrdenDeVenta.ToListAsync());
        }

        // GET: OrdenDeVentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenDeVenta = await _context.OrdenDeVenta
                .FirstOrDefaultAsync(m => m.IdOrdenDeVenta == id);
            if (ordenDeVenta == null)
            {
                return NotFound();
            }

            return View(ordenDeVenta);
        }

        // GET: OrdenDeVentas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrdenDeVentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOrdenDeVenta,CantidadDelProducto,ValorUnitario,ValorTotal")] OrdenDeVenta ordenDeVenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordenDeVenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ordenDeVenta);
        }

        // GET: OrdenDeVentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenDeVenta = await _context.OrdenDeVenta.FindAsync(id);
            if (ordenDeVenta == null)
            {
                return NotFound();
            }
            return View(ordenDeVenta);
        }

        // POST: OrdenDeVentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOrdenDeVenta,CantidadDelProducto,ValorUnitario,ValorTotal")] OrdenDeVenta ordenDeVenta)
        {
            if (id != ordenDeVenta.IdOrdenDeVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenDeVenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenDeVentaExists(ordenDeVenta.IdOrdenDeVenta))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ordenDeVenta);
        }

        // GET: OrdenDeVentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenDeVenta = await _context.OrdenDeVenta
                .FirstOrDefaultAsync(m => m.IdOrdenDeVenta == id);
            if (ordenDeVenta == null)
            {
                return NotFound();
            }

            return View(ordenDeVenta);
        }

        // POST: OrdenDeVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordenDeVenta = await _context.OrdenDeVenta.FindAsync(id);
            _context.OrdenDeVenta.Remove(ordenDeVenta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenDeVentaExists(int id)
        {
            return _context.OrdenDeVenta.Any(e => e.IdOrdenDeVenta == id);
        }
    }
}
