using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using examen.Data;
using examen.Models;

namespace examen.Controllers
{
    public class ProgramasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProgramasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Programas
        public async Task<IActionResult> Index()
        {
              return _context.Programa != null ? 
                          View(await _context.Programa.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Programa'  is null.");
        }

        // GET: Programas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Programa == null)
            {
                return NotFound();
            }

            var programa = await _context.Programa
                .FirstOrDefaultAsync(m => m.ProgramaId == id);
            if (programa == null)
            {
                return NotFound();
            }

            return View(programa);
        }

        // GET: Programas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Programas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgramaId,Name")] Programa programa)
        {
            if (ModelState.IsValid)
            {
                programa.ProgramaId = Guid.NewGuid();
                _context.Add(programa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(programa);
        }

        // GET: Programas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Programa == null)
            {
                return NotFound();
            }

            var programa = await _context.Programa.FindAsync(id);
            if (programa == null)
            {
                return NotFound();
            }
            return View(programa);
        }

        // POST: Programas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProgramaId,Name")] Programa programa)
        {
            if (id != programa.ProgramaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramaExists(programa.ProgramaId))
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
            return View(programa);
        }

        // GET: Programas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Programa == null)
            {
                return NotFound();
            }

            var programa = await _context.Programa
                .FirstOrDefaultAsync(m => m.ProgramaId == id);
            if (programa == null)
            {
                return NotFound();
            }

            return View(programa);
        }

        // POST: Programas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Programa == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Programa'  is null.");
            }
            var programa = await _context.Programa.FindAsync(id);
            if (programa != null)
            {
                _context.Programa.Remove(programa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramaExists(Guid id)
        {
          return (_context.Programa?.Any(e => e.ProgramaId == id)).GetValueOrDefault();
        }
    }
}
