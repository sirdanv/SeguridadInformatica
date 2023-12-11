using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeguridadInformatica.Data;
using SeguridadInformatica.Models;

namespace SeguridadInformatica.Controllers
{
    public class ActivosController : Controller
    {
        private readonly SeguridadInformaticaContext _context;

        public ActivosController(SeguridadInformaticaContext context)
        {
            _context = context;
        }

        // GET: Activos
        public async Task<IActionResult> Index()
        {
            var seguridadInformaticaContext = _context.Activos.Include(a => a.Usuarios);
            return View(await seguridadInformaticaContext.ToListAsync());
        }

        // GET: Activos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Activos == null)
            {
                return NotFound();
            }

            var activos = await _context.Activos
                .Include(a => a.Usuarios)
                .FirstOrDefaultAsync(m => m.ActivosId == id);
            if (activos == null)
            {
                return NotFound();
            }

            return View(activos);
        }

        // GET: Activos/Create
        public IActionResult Create()
        {
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "Usuario", "Usuario");
            return View();
        }

        // POST: Activos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActivosId,Tipo,Disponibilidad,Integridad,Confidencialidad,Descripcion,UsuariosId")] Activos activos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuariosId"] = new SelectList(_context.Usuarios, "UsuariosId", "UsuariosId", activos.UsuariosId);
            return View(activos);
        }

        // GET: Activos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Activos == null)
            {
                return NotFound();
            }

            var activos = await _context.Activos.FindAsync(id);
            if (activos == null)
            {
                return NotFound();
            }
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "Usuario", "Usuario", activos.UsuariosId);
            return View(activos);
        }

        // POST: Activos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActivosId,Tipo,Disponibilidad,Integridad,Confidencialidad,Descripcion,UsuariosId")] Activos activos)
        {
            if (id != activos.ActivosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivosExists(activos.ActivosId))
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
            ViewData["UsuariosId"] = new SelectList(_context.Usuarios, "UsuariosId", "UsuariosId", activos.UsuariosId);
            return View(activos);
        }

        // GET: Activos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Activos == null)
            {
                return NotFound();
            }

            var activos = await _context.Activos
                .Include(a => a.Usuarios)
                .FirstOrDefaultAsync(m => m.ActivosId == id);
            if (activos == null)
            {
                return NotFound();
            }

            return View(activos);
        }

        // POST: Activos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Activos == null)
            {
                return Problem("Entity set 'SeguridadInformaticaContext.Activos'  is null.");
            }
            var activos = await _context.Activos.FindAsync(id);
            if (activos != null)
            {
                _context.Activos.Remove(activos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivosExists(int id)
        {
            return (_context.Activos?.Any(e => e.ActivosId == id)).GetValueOrDefault();
        }
    }
}
