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

        public DimensionesController(SeguridadInformaticaContext context)
        {
            _context = context;
        }

        // GET: Dimensiones
        public async Task<IActionResult> Index()
        {
            var seguridadInformaticaContext = _context.Dimensiones.Include(d => d.Activos);
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
                .FirstOrDefaultAsync(m => m.DimesionesId == id);
            if (dimensiones == null)
            {
                return NotFound();
            }

            return View(dimensiones);
        }

        // GET: Dimensiones/Create
        public IActionResult Create()
        {
            ViewData["ActivosId"] = new SelectList(_context.Activos, "ActivosId", "ActivosId");
            return View();
        }

        // POST: Dimensiones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DimesionesId,Tipo,Valor,ActivosId")] Dimensiones dimensiones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dimensiones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActivosId"] = new SelectList(_context.Activos, "ActivosId", "ActivosId", dimensiones.ActivosId);
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
            ViewData["ActivosId"] = new SelectList(_context.Activos, "ActivosId", "ActivosId", dimensiones.ActivosId);
            return View(dimensiones);
        }

        // POST: Dimensiones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DimesionesId,Tipo,Valor,ActivosId")] Dimensiones dimensiones)
        {
            if (id != dimensiones.DimesionesId)
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
                    if (!DimensionesExists(dimensiones.DimesionesId))
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
                .FirstOrDefaultAsync(m => m.DimesionesId == id);
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
          return (_context.Dimensiones?.Any(e => e.DimesionesId == id)).GetValueOrDefault();
        }
    }
}
