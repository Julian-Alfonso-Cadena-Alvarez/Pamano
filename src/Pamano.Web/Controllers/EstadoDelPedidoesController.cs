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
    public class EstadoDelPedidoesController : Controller
    {
        private readonly PamanoDbContext _context;

        public EstadoDelPedidoesController(PamanoDbContext context)
        {
            _context = context;
        }

        // GET: EstadoDelPedidoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoDelPedido.ToListAsync());
        }

        // GET: EstadoDelPedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoDelPedido = await _context.EstadoDelPedido
                .FirstOrDefaultAsync(m => m.IdEstado == id);
            if (estadoDelPedido == null)
            {
                return NotFound();
            }

            return View(estadoDelPedido);
        }

        // GET: EstadoDelPedidoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoDelPedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstado,NombreEstadoDelPedido")] EstadoDelPedido estadoDelPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoDelPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoDelPedido);
        }

        // GET: EstadoDelPedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoDelPedido = await _context.EstadoDelPedido.FindAsync(id);
            if (estadoDelPedido == null)
            {
                return NotFound();
            }
            return View(estadoDelPedido);
        }

        // POST: EstadoDelPedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstado,NombreEstadoDelPedido")] EstadoDelPedido estadoDelPedido)
        {
            if (id != estadoDelPedido.IdEstado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoDelPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoDelPedidoExists(estadoDelPedido.IdEstado))
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
            return View(estadoDelPedido);
        }

        // GET: EstadoDelPedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoDelPedido = await _context.EstadoDelPedido
                .FirstOrDefaultAsync(m => m.IdEstado == id);
            if (estadoDelPedido == null)
            {
                return NotFound();
            }

            return View(estadoDelPedido);
        }

        // POST: EstadoDelPedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoDelPedido = await _context.EstadoDelPedido.FindAsync(id);
            _context.EstadoDelPedido.Remove(estadoDelPedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoDelPedidoExists(int id)
        {
            return _context.EstadoDelPedido.Any(e => e.IdEstado == id);
        }
    }
}
