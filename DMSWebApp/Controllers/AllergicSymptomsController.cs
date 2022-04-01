#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DMSWebApp.Models;

namespace DMSWebApp.Controllers
{
    public class AllergicSymptomsController : Controller
    {
        private readonly IdentityModel _context;

        public AllergicSymptomsController(IdentityModel context)
        {
            _context = context;
        }

        // GET: AllergicSymptoms
        public async Task<IActionResult> Index()
        {
            return View(await _context.AllergicSymptoms.ToListAsync());
        }

        // GET: AllergicSymptoms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allergicSymptom = await _context.AllergicSymptoms
                .FirstOrDefaultAsync(m => m.AllergicSymptomId == id);
            if (allergicSymptom == null)
            {
                return NotFound();
            }

            return View(allergicSymptom);
        }

        // GET: AllergicSymptoms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AllergicSymptoms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AllergicSymptomId,AllergyName,Description")] AllergicSymptom allergicSymptom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allergicSymptom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allergicSymptom);
        }

        // GET: AllergicSymptoms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allergicSymptom = await _context.AllergicSymptoms.FindAsync(id);
            if (allergicSymptom == null)
            {
                return NotFound();
            }
            return View(allergicSymptom);
        }

        // POST: AllergicSymptoms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AllergicSymptomId,AllergyName,Description")] AllergicSymptom allergicSymptom)
        {
            if (id != allergicSymptom.AllergicSymptomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allergicSymptom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllergicSymptomExists(allergicSymptom.AllergicSymptomId))
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
            return View(allergicSymptom);
        }

        // GET: AllergicSymptoms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allergicSymptom = await _context.AllergicSymptoms
                .FirstOrDefaultAsync(m => m.AllergicSymptomId == id);
            if (allergicSymptom == null)
            {
                return NotFound();
            }

            return View(allergicSymptom);
        }

        // POST: AllergicSymptoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allergicSymptom = await _context.AllergicSymptoms.FindAsync(id);
            _context.AllergicSymptoms.Remove(allergicSymptom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllergicSymptomExists(int id)
        {
            return _context.AllergicSymptoms.Any(e => e.AllergicSymptomId == id);
        }
    }
}
