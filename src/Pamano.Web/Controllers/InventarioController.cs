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
    public class InventarioController : Controller
    {
        private readonly PamanoDbContext _context;

        public InventarioController(PamanoDbContext context)
        {
            _context = context;
        }

        // GET: Inventario
        public async Task<IActionResult> Index()
        {
            var pamanoDbContext = _context.Inventario.Include(i => i.IdOrdenDeCompraNavigation).Include(i => i.IdOrdenDeVentaNavigation).Include(i => i.IdPedidoNavigation).Include(i => i.IdProductoNavigation).Include(i => i.IdUsuarioNavigation);
            return View(await pamanoDbContext.ToListAsync());
        }

        // GET: Inventario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventario
                .Include(i => i.IdOrdenDeCompraNavigation)
                .Include(i => i.IdOrdenDeVentaNavigation)
                .Include(i => i.IdPedidoNavigation)
                .Include(i => i.IdProductoNavigation)
                .Include(i => i.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdInventario == id);
            if (inventario == null)
            {
                return NotFound();
            }

            return View(inventario);
        }

        // GET: Inventario/Create
        public IActionResult Create()
        {
            ViewData["IdOrdenDeCompra"] = new SelectList(_context.OrdenDeCompra, "IdOrdenDeCompra", "IdOrdenDeCompra");
            ViewData["IdOrdenDeVenta"] = new SelectList(_context.OrdenDeVenta, "IdOrdenDeVenta", "IdOrdenDeVenta");
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido");
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "IdProducto");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: Inventario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInventario,FechaDeIngreso,IdUsuario,IdOrdenDeCompra,IdOrdenDeVenta,IdPedido,IdProducto")] Inventario inventario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdOrdenDeCompra"] = new SelectList(_context.OrdenDeCompra, "IdOrdenDeCompra", "IdOrdenDeCompra", inventario.IdOrdenDeCompra);
            ViewData["IdOrdenDeVenta"] = new SelectList(_context.OrdenDeVenta, "IdOrdenDeVenta", "IdOrdenDeVenta", inventario.IdOrdenDeVenta);
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido", inventario.IdPedido);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "IdProducto", inventario.IdProducto);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", inventario.IdUsuario);
            return View(inventario);
        }

        // GET: Inventario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventario.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }
            ViewData["IdOrdenDeCompra"] = new SelectList(_context.OrdenDeCompra, "IdOrdenDeCompra", "IdOrdenDeCompra", inventario.IdOrdenDeCompra);
            ViewData["IdOrdenDeVenta"] = new SelectList(_context.OrdenDeVenta, "IdOrdenDeVenta", "IdOrdenDeVenta", inventario.IdOrdenDeVenta);
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido", inventario.IdPedido);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "IdProducto", inventario.IdProducto);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", inventario.IdUsuario);
            return View(inventario);
        }

        // POST: Inventario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInventario,FechaDeIngreso,IdUsuario,IdOrdenDeCompra,IdOrdenDeVenta,IdPedido,IdProducto")] Inventario inventario)
        {
            if (id != inventario.IdInventario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventarioExists(inventario.IdInventario))
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
            ViewData["IdOrdenDeCompra"] = new SelectList(_context.OrdenDeCompra, "IdOrdenDeCompra", "IdOrdenDeCompra", inventario.IdOrdenDeCompra);
            ViewData["IdOrdenDeVenta"] = new SelectList(_context.OrdenDeVenta, "IdOrdenDeVenta", "IdOrdenDeVenta", inventario.IdOrdenDeVenta);
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido", inventario.IdPedido);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "IdProducto", inventario.IdProducto);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", inventario.IdUsuario);
            return View(inventario);
        }

        // GET: Inventario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventario
                .Include(i => i.IdOrdenDeCompraNavigation)
                .Include(i => i.IdOrdenDeVentaNavigation)
                .Include(i => i.IdPedidoNavigation)
                .Include(i => i.IdProductoNavigation)
                .Include(i => i.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdInventario == id);
            if (inventario == null)
            {
                return NotFound();
            }

            return View(inventario);
        }

        // POST: Inventario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventario = await _context.Inventario.FindAsync(id);
            _context.Inventario.Remove(inventario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventarioExists(int id)
        {
            return _context.Inventario.Any(e => e.IdInventario == id);
        }
    }
}
