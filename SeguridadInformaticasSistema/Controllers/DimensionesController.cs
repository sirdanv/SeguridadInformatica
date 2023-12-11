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
    public class DimensionesController : Controller
    {
        private readonly SeguridadInformaticaContext _context;

        private float EvaluacionActivos(Activos activos, Dimensiones dimensiones)
        {
            float resultado = ((activos.Disponibilidad * dimensiones.Disponibilidad) + (activos.Integridad * dimensiones.Integridad) + (activos.Confidencialidad * dimensiones.Confidencialidad));

            return resultado;
        }

        public DimensionesController(SeguridadInformaticaContext context)
        {
            _context = context;
        }

        // GET: Dimensiones
        public async Task<IActionResult> Index()
        {
            var seguridadInformaticaContext = _context.Dimensiones.Include(d => d.Activos).Include(d => d.Usuarios);
            var activos = await _context.Activos.FirstOrDefaultAsync();
            var dimensiones = await _context.Dimensiones.FirstOrDefaultAsync();

            if (activos != null && dimensiones != null)
            {
                dimensiones.Evaluacion = (int)EvaluacionActivos(activos, dimensiones);
                await _context.SaveChangesAsync();
            }

            return View(await seguridadInformaticaContext.ToListAsync());
        }

        // GET: Dimensiones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dimensiones == null)
            {
                return NotFound();
            }

            var dimensiones = await _context.Dimensiones
                .Include(d => d.Activos)
                .Include(d => d.Usuarios)
                .FirstOrDefaultAsync(m => m.DimensionesId == id);
            if (dimensiones == null)
            {
                return NotFound();
            }

            return View(dimensiones);
        }

        // GET: Dimensiones/Create
        public IActionResult Create()
        {
            ViewData["Tipo"] = new SelectList(_context.Activos, "Tipo", "Tipo");
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "Usuario", "Usuario");
            return View();
        }

        // POST: Dimensiones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DimensionesId,Disponibilidad,Integridad,Confidencialidad,UsuariosId,ActivosId")] Dimensiones dimensiones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dimensiones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActivosId"] = new SelectList(_context.Activos, "ActivosId", "ActivosId", dimensiones.ActivosId);
            ViewData["UsuariosId"] = new SelectList(_context.Usuarios, "UsuariosId", "UsuariosId", dimensiones.UsuariosId);
            return View(dimensiones);
        }

        // GET: Dimensiones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Dimensiones == null)
            {
                return NotFound();
            }

            var dimensiones = await _context.Dimensiones.FindAsync(id);
            if (dimensiones == null)
            {
                return NotFound();
            }
            ViewData["Tipo"] = new SelectList(_context.Activos, "Tipo", "Tipo", dimensiones.ActivosId);
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "Usuario", "Usuario", dimensiones.UsuariosId);
            return View(dimensiones);
        }

        // POST: Dimensiones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DimensionesId,Disponibilidad,Integridad,Confidencialidad,UsuariosId,ActivosId")] Dimensiones dimensiones)
        {
            if (id != dimensiones.DimensionesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dimensiones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DimensionesExists(dimensiones.DimensionesId))
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
            ViewData["ActivosId"] = new SelectList(_context.Activos, "ActivosId", "ActivosId", dimensiones.ActivosId);
            ViewData["UsuariosId"] = new SelectList(_context.Usuarios, "UsuariosId", "UsuariosId", dimensiones.UsuariosId);
            return View(dimensiones);
        }

        // GET: Dimensiones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dimensiones == null)
            {
                return NotFound();
            }

            var dimensiones = await _context.Dimensiones
                .Include(d => d.Activos)
                .Include(d => d.Usuarios)
                .FirstOrDefaultAsync(m => m.DimensionesId == id);
            if (dimensiones == null)
            {
                return NotFound();
            }

            return View(dimensiones);
        }

        // POST: Dimensiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dimensiones == null)
            {
                return Problem("Entity set 'SeguridadInformaticaContext.Dimensiones'  is null.");
            }
            var dimensiones = await _context.Dimensiones.FindAsync(id);
            if (dimensiones != null)
            {
                _context.Dimensiones.Remove(dimensiones);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DimensionesExists(int id)
        {
            return (_context.Dimensiones?.Any(e => e.DimensionesId == id)).GetValueOrDefault();
        }
    }
}