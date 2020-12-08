using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pamano.Infrastructure;
using Pamano.Infrastructure.Data;
using Pamano.Core.Domain;


namespace Pamano.Web.Controllers
{
    public class OrdenDeComprasController : Controller
    {
        private readonly PamanoDbContext _context;

        public OrdenDeComprasController(PamanoDbContext context)
        {
            _context = context;
        }
        public IActionResult Principal()
        {
            return View();
        }
        public IActionResult Reporte()
        {
            return View();
        }
        // GET: OrdenDeCompras
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrdenDeCompra.ToListAsync());
        }

        // GET: OrdenDeCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenDeCompra = await _context.OrdenDeCompra
                .FirstOrDefaultAsync(m => m.IdOrdenDeCompra == id);
            if (ordenDeCompra == null)
            {
                return NotFound();
            }

            return View(ordenDeCompra);
        }

        // GET: OrdenDeCompras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrdenDeCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOrdenDeCompra,NombreDelProveedor,ValorUnitarioDelProducto,ValorTotalDelProducto,Producto")] OrdenDeCompra ordenDeCompra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordenDeCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ordenDeCompra);
        }

        // GET: OrdenDeCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenDeCompra = await _context.OrdenDeCompra.FindAsync(id);
            if (ordenDeCompra == null)
            {
                return NotFound();
            }
            return View(ordenDeCompra);
        }

        // POST: OrdenDeCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOrdenDeCompra,NombreDelProveedor,ValorUnitarioDelProducto,ValorTotalDelProducto,Producto")] OrdenDeCompra ordenDeCompra)
        {
            if (id != ordenDeCompra.IdOrdenDeCompra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenDeCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenDeCompraExists(ordenDeCompra.IdOrdenDeCompra))
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
            return View(ordenDeCompra);
        }

        // GET: OrdenDeCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenDeCompra = await _context.OrdenDeCompra
                .FirstOrDefaultAsync(m => m.IdOrdenDeCompra == id);
            if (ordenDeCompra == null)
            {
                return NotFound();
            }

            return View(ordenDeCompra);
        }

        // POST: OrdenDeCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordenDeCompra = await _context.OrdenDeCompra.FindAsync(id);
            _context.OrdenDeCompra.Remove(ordenDeCompra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenDeCompraExists(int id)
        {
            return _context.OrdenDeCompra.Any(e => e.IdOrdenDeCompra == id);
        }
    }
}
