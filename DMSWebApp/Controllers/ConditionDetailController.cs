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
    public class ConditionDetailController : Controller
    {
        private readonly IdentityModel _context;

        public ConditionDetailController(IdentityModel context)
        {
            _context = context;
        }

        // GET: ConditionDetail
        public async Task<IActionResult> Index()
        {
            var identityModel = _context.ConditionDetails.Include(c => c.AllergicSymptom);
            return View(await identityModel.ToListAsync());
        }

        // GET: ConditionDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conditionDetail = await _context.ConditionDetails
                .Include(c => c.AllergicSymptom)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conditionDetail == null)
            {
                return NotFound();
            }

            return View(conditionDetail);
        }

        // GET: ConditionDetail/Create
        public IActionResult Create()
        {
            ViewData["AllergicSymptomId"] = new SelectList(_context.AllergicSymptoms, "AllergicSymptomId", "AllergyName");
            return View();
        }

        // POST: ConditionDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,AllergicSymptomId")] ConditionDetail conditionDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conditionDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AllergicSymptomId"] = new SelectList(_context.AllergicSymptoms, "AllergicSymptomId", "AllergyName", conditionDetail.AllergicSymptomId);
            return View(conditionDetail);
        }

        // GET: ConditionDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conditionDetail = await _context.ConditionDetails.FindAsync(id);
            if (conditionDetail == null)
            {
                return NotFound();
            }
            ViewData["AllergicSymptomId"] = new SelectList(_context.AllergicSymptoms, "AllergicSymptomId", "AllergyName", conditionDetail.AllergicSymptomId);
            return View(conditionDetail);
        }

        // POST: ConditionDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,AllergicSymptomId")] ConditionDetail conditionDetail)
        {
            if (id != conditionDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conditionDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConditionDetailExists(conditionDetail.Id))
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
            ViewData["AllergicSymptomId"] = new SelectList(_context.AllergicSymptoms, "AllergicSymptomId", "AllergyName", conditionDetail.AllergicSymptomId);
            return View(conditionDetail);
        }

        // GET: ConditionDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conditionDetail = await _context.ConditionDetails
                .Include(c => c.AllergicSymptom)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conditionDetail == null)
            {
                return NotFound();
            }

            return View(conditionDetail);
        }

        // POST: ConditionDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conditionDetail = await _context.ConditionDetails.FindAsync(id);
            _context.ConditionDetails.Remove(conditionDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConditionDetailExists(int id)
        {
            return _context.ConditionDetails.Any(e => e.Id == id);
        }
    }
}
