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
using Microsoft.AspNetCore.Authorization;

namespace Pamano.Web.Controllers
{
    
    public class ProductoController : Controller
    {
        private readonly PamanoDbContext _context;

        public ProductoController(PamanoDbContext context)
        {
            _context = context;
        }

        // GET: Producto
        public async Task<IActionResult> Index()
        {
            var pamanoDbContext = _context.Producto.Include(p => p.IdTipoDeProductoNavigation);
            return View(await pamanoDbContext.ToListAsync());
        }

        // GET: Producto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto
                .Include(p => p.IdTipoDeProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }
        [Authorize]
        // GET: Producto/Create
        public IActionResult Create()
        {
            ViewData["IdTipoDeProducto"] = new SelectList(_context.TipoDeProducto, "IdTipoProducto", "IdTipoProducto");
            return View();
        }

        // POST: Producto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("IdProducto,CantidadDeProducto,IdTipoDeProducto,PrecioDelProducto,CaracteristicasDelProducto")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoDeProducto"] = new SelectList(_context.TipoDeProducto, "IdTipoProducto", "IdTipoProducto", producto.IdTipoDeProducto);
            return View(producto);
        }

        // GET: Producto/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["IdTipoDeProducto"] = new SelectList(_context.TipoDeProducto, "IdTipoProducto", "IdTipoProducto", producto.IdTipoDeProducto);
            return View(producto);
        }

        // POST: Producto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProducto,CantidadDeProducto,IdTipoDeProducto,PrecioDelProducto,CaracteristicasDelProducto")] Producto producto)
        {
            if (id != producto.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.IdProducto))
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
            ViewData["IdTipoDeProducto"] = new SelectList(_context.TipoDeProducto, "IdTipoProducto", "IdTipoProducto", producto.IdTipoDeProducto);
            return View(producto);
        }

        // GET: Producto/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto
                .Include(p => p.IdTipoDeProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Producto.FindAsync(id);
            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Producto.Any(e => e.IdProducto == id);
        }
    }
}
