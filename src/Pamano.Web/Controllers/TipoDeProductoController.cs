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
    public class TipoDeProductoController : Controller
    {
        private readonly PamanoDbContext _context;

        public TipoDeProductoController(PamanoDbContext context)
        {
            _context = context;
        }

        // GET: TipoDeProducto
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoDeProducto.ToListAsync());
        }

        // GET: TipoDeProducto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeProducto = await _context.TipoDeProducto
                .FirstOrDefaultAsync(m => m.IdTipoProducto == id);
            if (tipoDeProducto == null)
            {
                return NotFound();
            }

            return View(tipoDeProducto);
        }

        // GET: TipoDeProducto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDeProducto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoProducto,NombreProducto")] TipoDeProducto tipoDeProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDeProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDeProducto);
        }

        // GET: TipoDeProducto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeProducto = await _context.TipoDeProducto.FindAsync(id);
            if (tipoDeProducto == null)
            {
                return NotFound();
            }
            return View(tipoDeProducto);
        }

        // POST: TipoDeProducto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoProducto,NombreProducto")] TipoDeProducto tipoDeProducto)
        {
            if (id != tipoDeProducto.IdTipoProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDeProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDeProductoExists(tipoDeProducto.IdTipoProducto))
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
            return View(tipoDeProducto);
        }

        // GET: TipoDeProducto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeProducto = await _context.TipoDeProducto
                .FirstOrDefaultAsync(m => m.IdTipoProducto == id);
            if (tipoDeProducto == null)
            {
                return NotFound();
            }

            return View(tipoDeProducto);
        }

        // POST: TipoDeProducto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoDeProducto = await _context.TipoDeProducto.FindAsync(id);
            _context.TipoDeProducto.Remove(tipoDeProducto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDeProductoExists(int id)
        {
            return _context.TipoDeProducto.Any(e => e.IdTipoProducto == id);
        }
    }
}
