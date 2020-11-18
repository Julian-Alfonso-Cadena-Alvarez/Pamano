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
    public class TipoDeTelefonoController : Controller
    {
        private readonly PamanoDbContext _context;

        public TipoDeTelefonoController(PamanoDbContext context)
        {
            _context = context;
        }

        // GET: TipoDeTelefono
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoDeTelefono.ToListAsync());
        }

        // GET: TipoDeTelefono/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeTelefono = await _context.TipoDeTelefono
                .FirstOrDefaultAsync(m => m.IdTipoTelefono == id);
            if (tipoDeTelefono == null)
            {
                return NotFound();
            }

            return View(tipoDeTelefono);
        }

        // GET: TipoDeTelefono/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDeTelefono/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoTelefono,TipoTelefono")] TipoDeTelefono tipoDeTelefono)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDeTelefono);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDeTelefono);
        }

        // GET: TipoDeTelefono/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeTelefono = await _context.TipoDeTelefono.FindAsync(id);
            if (tipoDeTelefono == null)
            {
                return NotFound();
            }
            return View(tipoDeTelefono);
        }

        // POST: TipoDeTelefono/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoTelefono,TipoTelefono")] TipoDeTelefono tipoDeTelefono)
        {
            if (id != tipoDeTelefono.IdTipoTelefono)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDeTelefono);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDeTelefonoExists(tipoDeTelefono.IdTipoTelefono))
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
            return View(tipoDeTelefono);
        }

        // GET: TipoDeTelefono/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeTelefono = await _context.TipoDeTelefono
                .FirstOrDefaultAsync(m => m.IdTipoTelefono == id);
            if (tipoDeTelefono == null)
            {
                return NotFound();
            }

            return View(tipoDeTelefono);
        }

        // POST: TipoDeTelefono/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoDeTelefono = await _context.TipoDeTelefono.FindAsync(id);
            _context.TipoDeTelefono.Remove(tipoDeTelefono);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDeTelefonoExists(int id)
        {
            return _context.TipoDeTelefono.Any(e => e.IdTipoTelefono == id);
        }
    }
}
