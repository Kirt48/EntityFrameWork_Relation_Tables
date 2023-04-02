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
    public class ProfessionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfessionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Professions
        public async Task<IActionResult> Index()
        {
              return _context.Profession != null ? 
                          View(await _context.Profession.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Profession'  is null.");
        }

        // GET: Professions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Profession == null)
            {
                return NotFound();
            }

            var profession = await _context.Profession
                .FirstOrDefaultAsync(m => m.ProfessionId == id);
            if (profession == null)
            {
                return NotFound();
            }

            return View(profession);
        }

        // GET: Professions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Professions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfessionId,Name")] Profession profession)
        {
            if (ModelState.IsValid)
            {
                profession.ProfessionId = Guid.NewGuid();
                _context.Add(profession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profession);
        }

        // GET: Professions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Profession == null)
            {
                return NotFound();
            }

            var profession = await _context.Profession.FindAsync(id);
            if (profession == null)
            {
                return NotFound();
            }
            return View(profession);
        }

        // POST: Professions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProfessionId,Name")] Profession profession)
        {
            if (id != profession.ProfessionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessionExists(profession.ProfessionId))
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
            return View(profession);
        }

        // GET: Professions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Profession == null)
            {
                return NotFound();
            }

            var profession = await _context.Profession
                .FirstOrDefaultAsync(m => m.ProfessionId == id);
            if (profession == null)
            {
                return NotFound();
            }

            return View(profession);
        }

        // POST: Professions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Profession == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Profession'  is null.");
            }
            var profession = await _context.Profession.FindAsync(id);
            if (profession != null)
            {
                _context.Profession.Remove(profession);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessionExists(Guid id)
        {
          return (_context.Profession?.Any(e => e.ProfessionId == id)).GetValueOrDefault();
        }
    }
}
