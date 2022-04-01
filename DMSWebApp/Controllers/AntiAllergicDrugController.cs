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
    public class AntiAllergicDrugController : Controller
    {
        private readonly IdentityModel _context;

        public AntiAllergicDrugController(IdentityModel context)
        {
            _context = context;
        }

        // GET: AntiAllergicDrug
        public async Task<IActionResult> Index()
        {
            return View(await _context.AntiAllergicDrugs.ToListAsync());
        }

        // GET: AntiAllergicDrug/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antiAllergicDrug = await _context.AntiAllergicDrugs
                .FirstOrDefaultAsync(m => m.AntiAllergicDrugId == id);
            if (antiAllergicDrug == null)
            {
                return NotFound();
            }

            return View(antiAllergicDrug);
        }

        // GET: AntiAllergicDrug/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AntiAllergicDrug/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AntiAllergicDrugId,ShortName,LongName,SpecialDescription")] AntiAllergicDrug antiAllergicDrug)
        {
            if (ModelState.IsValid)
            {
                _context.Add(antiAllergicDrug);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(antiAllergicDrug);
        }

        // GET: AntiAllergicDrug/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antiAllergicDrug = await _context.AntiAllergicDrugs.FindAsync(id);
            if (antiAllergicDrug == null)
            {
                return NotFound();
            }
            return View(antiAllergicDrug);
        }

        // POST: AntiAllergicDrug/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AntiAllergicDrugId,ShortName,LongName,SpecialDescription")] AntiAllergicDrug antiAllergicDrug)
        {
            if (id != antiAllergicDrug.AntiAllergicDrugId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(antiAllergicDrug);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AntiAllergicDrugExists(antiAllergicDrug.AntiAllergicDrugId))
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
            return View(antiAllergicDrug);
        }

        // GET: AntiAllergicDrug/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antiAllergicDrug = await _context.AntiAllergicDrugs
                .FirstOrDefaultAsync(m => m.AntiAllergicDrugId == id);
            if (antiAllergicDrug == null)
            {
                return NotFound();
            }

            return View(antiAllergicDrug);
        }

        // POST: AntiAllergicDrug/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var antiAllergicDrug = await _context.AntiAllergicDrugs.FindAsync(id);
            _context.AntiAllergicDrugs.Remove(antiAllergicDrug);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AntiAllergicDrugExists(int id)
        {
            return _context.AntiAllergicDrugs.Any(e => e.AntiAllergicDrugId == id);
        }
    }
}
