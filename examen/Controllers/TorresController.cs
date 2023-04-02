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
    public class TorresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TorresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Torres
        public async Task<IActionResult> Index()
        {
              return _context.Torre != null ? 
                          View(await _context.Torre.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Torre'  is null.");
        }

        // GET: Torres/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Torre == null)
            {
                return NotFound();
            }

            var torre = await _context.Torre
                .FirstOrDefaultAsync(m => m.TorreId == id);
            if (torre == null)
            {
                return NotFound();
            }

            return View(torre);
        }

        // GET: Torres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Torres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TorreId,Zone")] Torre torre)
        {
            if (ModelState.IsValid)
            {
                torre.TorreId = Guid.NewGuid();
                _context.Add(torre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(torre);
        }

        // GET: Torres/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Torre == null)
            {
                return NotFound();
            }

            var torre = await _context.Torre.FindAsync(id);
            if (torre == null)
            {
                return NotFound();
            }
            return View(torre);
        }

        // POST: Torres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TorreId,Zone")] Torre torre)
        {
            if (id != torre.TorreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(torre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TorreExists(torre.TorreId))
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
            return View(torre);
        }

        // GET: Torres/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Torre == null)
            {
                return NotFound();
            }

            var torre = await _context.Torre
                .FirstOrDefaultAsync(m => m.TorreId == id);
            if (torre == null)
            {
                return NotFound();
            }

            return View(torre);
        }

        // POST: Torres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Torre == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Torre'  is null.");
            }
            var torre = await _context.Torre.FindAsync(id);
            if (torre != null)
            {
                _context.Torre.Remove(torre);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TorreExists(Guid id)
        {
          return (_context.Torre?.Any(e => e.TorreId == id)).GetValueOrDefault();
        }
    }
}
