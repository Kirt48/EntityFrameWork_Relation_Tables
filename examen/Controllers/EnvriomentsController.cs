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
    public class EnvriomentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnvriomentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Envrioments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Envrioment.Include(e => e.Instructor).Include(e => e.Torre);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Envrioments/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Envrioment == null)
            {
                return NotFound();
            }

            var envrioment = await _context.Envrioment
                .Include(e => e.Instructor)
                .Include(e => e.Torre)
                .FirstOrDefaultAsync(m => m.EnvriomentId == id);
            if (envrioment == null)
            {
                return NotFound();
            }

            return View(envrioment);
        }

        // GET: Envrioments/Create
        public IActionResult Create()
        {
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "Id", "Document");
            ViewData["TorreId"] = new SelectList(_context.Torre, "TorreId", "Zone");
            return View();
        }

        // POST: Envrioments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnvriomentId,Code,Floor,InstructorId,TorreId")] Envrioment envrioment)
        {
            if (ModelState.IsValid)
            {
                envrioment.EnvriomentId = Guid.NewGuid();
                _context.Add(envrioment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "Id", "Document", envrioment.InstructorId);
            ViewData["TorreId"] = new SelectList(_context.Torre, "TorreId", "Zone", envrioment.TorreId);
            return View(envrioment);
        }

        // GET: Envrioments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Envrioment == null)
            {
                return NotFound();
            }

            var envrioment = await _context.Envrioment.FindAsync(id);
            if (envrioment == null)
            {
                return NotFound();
            }
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "Id", "Document", envrioment.InstructorId);
            ViewData["TorreId"] = new SelectList(_context.Torre, "TorreId", "Zone", envrioment.TorreId);
            return View(envrioment);
        }

        // POST: Envrioments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("EnvriomentId,Code,Floor,InstructorId,TorreId")] Envrioment envrioment)
        {
            if (id != envrioment.EnvriomentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(envrioment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnvriomentExists(envrioment.EnvriomentId))
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
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "Id", "Document", envrioment.InstructorId);
            ViewData["TorreId"] = new SelectList(_context.Torre, "TorreId", "Zone", envrioment.TorreId);
            return View(envrioment);
        }

        // GET: Envrioments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Envrioment == null)
            {
                return NotFound();
            }

            var envrioment = await _context.Envrioment
                .Include(e => e.Instructor)
                .Include(e => e.Torre)
                .FirstOrDefaultAsync(m => m.EnvriomentId == id);
            if (envrioment == null)
            {
                return NotFound();
            }

            return View(envrioment);
        }

        // POST: Envrioments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Envrioment == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Envrioment'  is null.");
            }
            var envrioment = await _context.Envrioment.FindAsync(id);
            if (envrioment != null)
            {
                _context.Envrioment.Remove(envrioment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnvriomentExists(Guid id)
        {
          return (_context.Envrioment?.Any(e => e.EnvriomentId == id)).GetValueOrDefault();
        }
    }
}
