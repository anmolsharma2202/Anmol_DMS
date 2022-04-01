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
    public class AntiAllergicDrugSymptomsController : Controller
    {
        private readonly IdentityModel _context;

        public AntiAllergicDrugSymptomsController(IdentityModel context)
        {
            _context = context;
        }

        // GET: AntiAllergicDrugSymptoms
        public async Task<IActionResult> Index()
        {
            return View(await _context.AntiAllergicDrugSymptoms.ToListAsync());
        }

        // GET: AntiAllergicDrugSymptoms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antiAllergicDrugSymptom = await _context.AntiAllergicDrugSymptoms
                .FirstOrDefaultAsync(m => m.AntiAllergicDrugSymptomId == id);
            if (antiAllergicDrugSymptom == null)
            {
                return NotFound();
            }

            return View(antiAllergicDrugSymptom);
        }

        // GET: AntiAllergicDrugSymptoms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AntiAllergicDrugSymptoms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AntiAllergicDrugSymptomId,AntiAllergicDrugName,AllergyName,SpecialDescription")] AntiAllergicDrugSymptom antiAllergicDrugSymptom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(antiAllergicDrugSymptom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(antiAllergicDrugSymptom);
        }

        // GET: AntiAllergicDrugSymptoms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antiAllergicDrugSymptom = await _context.AntiAllergicDrugSymptoms.FindAsync(id);
            if (antiAllergicDrugSymptom == null)
            {
                return NotFound();
            }
            return View(antiAllergicDrugSymptom);
        }

        // POST: AntiAllergicDrugSymptoms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AntiAllergicDrugSymptomId,AntiAllergicDrugName,AllergyName,SpecialDescription")] AntiAllergicDrugSymptom antiAllergicDrugSymptom)
        {
            if (id != antiAllergicDrugSymptom.AntiAllergicDrugSymptomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(antiAllergicDrugSymptom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AntiAllergicDrugSymptomExists(antiAllergicDrugSymptom.AntiAllergicDrugSymptomId))
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
            return View(antiAllergicDrugSymptom);
        }

        // GET: AntiAllergicDrugSymptoms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antiAllergicDrugSymptom = await _context.AntiAllergicDrugSymptoms
                .FirstOrDefaultAsync(m => m.AntiAllergicDrugSymptomId == id);
            if (antiAllergicDrugSymptom == null)
            {
                return NotFound();
            }

            return View(antiAllergicDrugSymptom);
        }

        // POST: AntiAllergicDrugSymptoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var antiAllergicDrugSymptom = await _context.AntiAllergicDrugSymptoms.FindAsync(id);
            _context.AntiAllergicDrugSymptoms.Remove(antiAllergicDrugSymptom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AntiAllergicDrugSymptomExists(int id)
        {
            return _context.AntiAllergicDrugSymptoms.Any(e => e.AntiAllergicDrugSymptomId == id);
        }
    }
}
