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
    public class TelefonoController : Controller
    {
        private readonly PamanoDbContext _context;

        public TelefonoController(PamanoDbContext context)
        {
            _context = context;
        }

        // GET: Telefono
        public async Task<IActionResult> Index()
        {
            var pamanoDbContext = _context.Telefono.Include(t => t.IdTipoTelefonoNavigation);
            return View(await pamanoDbContext.ToListAsync());
        }

        // GET: Telefono/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _context.Telefono
                .Include(t => t.IdTipoTelefonoNavigation)
                .FirstOrDefaultAsync(m => m.IdTelefono == id);
            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }

        // GET: Telefono/Create
        public IActionResult Create()
        {
            ViewData["IdTipoTelefono"] = new SelectList(_context.TipoDeTelefono, "IdTipoTelefono", "IdTipoTelefono");
            return View();
        }

        // POST: Telefono/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTelefono,IdTipoTelefono,NumeroTelefonico")] Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefono);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoTelefono"] = new SelectList(_context.TipoDeTelefono, "IdTipoTelefono", "IdTipoTelefono", telefono.IdTipoTelefono);
            return View(telefono);
        }

        // GET: Telefono/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _context.Telefono.FindAsync(id);
            if (telefono == null)
            {
                return NotFound();
            }
            ViewData["IdTipoTelefono"] = new SelectList(_context.TipoDeTelefono, "IdTipoTelefono", "IdTipoTelefono", telefono.IdTipoTelefono);
            return View(telefono);
        }

        // POST: Telefono/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTelefono,IdTipoTelefono,NumeroTelefonico")] Telefono telefono)
        {
            if (id != telefono.IdTelefono)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefono);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefonoExists(telefono.IdTelefono))
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
            ViewData["IdTipoTelefono"] = new SelectList(_context.TipoDeTelefono, "IdTipoTelefono", "IdTipoTelefono", telefono.IdTipoTelefono);
            return View(telefono);
        }

        // GET: Telefono/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _context.Telefono
                .Include(t => t.IdTipoTelefonoNavigation)
                .FirstOrDefaultAsync(m => m.IdTelefono == id);
            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }

        // POST: Telefono/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telefono = await _context.Telefono.FindAsync(id);
            _context.Telefono.Remove(telefono);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefonoExists(int id)
        {
            return _context.Telefono.Any(e => e.IdTelefono == id);
        }
    }
}
