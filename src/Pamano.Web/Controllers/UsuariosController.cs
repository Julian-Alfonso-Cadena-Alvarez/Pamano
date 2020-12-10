using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pamano.Core.Domain;
using Pamano.Infrastructure.Data;

namespace Pamano.Web.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly PamanoDbContext _context;

        public UsuariosController(PamanoDbContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var pamanoDbContext = _context.Usuarios.Include(u => u.IdRolNavigation).Include(u => u.IdTipoTelefonoNavigation);
            return View(await pamanoDbContext.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios
                .Include(u => u.IdRolNavigation)
                .Include(u => u.IdTipoTelefonoNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["IdRol"] = new SelectList(_context.Rol, "IdRol", "IdRol");
            ViewData["IdTipoTelefono"] = new SelectList(_context.TipoDeTelefono, "IdTipoTelefono", "IdTipoTelefono");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,IdRol,IdTipoTelefono,Telefono,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRol"] = new SelectList(_context.Rol, "IdRol", "IdRol", usuarios.IdRol);
            ViewData["IdTipoTelefono"] = new SelectList(_context.TipoDeTelefono, "IdTipoTelefono", "IdTipoTelefono", usuarios.IdTipoTelefono);
            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }
            ViewData["IdRol"] = new SelectList(_context.Rol, "IdRol", "IdRol", usuarios.IdRol);
            ViewData["IdTipoTelefono"] = new SelectList(_context.TipoDeTelefono, "IdTipoTelefono", "IdTipoTelefono", usuarios.IdTipoTelefono);
            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdUsuario,IdRol,IdTipoTelefono,Telefono,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido")] Usuarios usuarios)
        {
            if (id != usuarios.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuariosExists(usuarios.IdUsuario))
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
            ViewData["IdRol"] = new SelectList(_context.Rol, "IdRol", "IdRol", usuarios.IdRol);
            ViewData["IdTipoTelefono"] = new SelectList(_context.TipoDeTelefono, "IdTipoTelefono", "IdTipoTelefono", usuarios.IdTipoTelefono);
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios
                .Include(u => u.IdRolNavigation)
                .Include(u => u.IdTipoTelefonoNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var usuarios = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuariosExists(string id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }
    }
}
