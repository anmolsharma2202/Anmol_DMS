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
    public class UsageConditionController : Controller
    {
        private readonly IdentityModel _context;

        public UsageConditionController(IdentityModel context)
        {
            _context = context;
        }

        // GET: UsageCondition
        public async Task<IActionResult> Index()
        {
            return View(await _context.UsageConditions.ToListAsync());
        }

        //public async Task<IActionResult> Index(string id)
        //{
        //    var drugname = from m in _context.Drugs
        //                 select m;

        //    if (!String.IsNullOrEmpty(id))
        //    {
        //        drugname = drugname.Where(s => (s.ShortName!.Contains(id) || s.LongName!.Contains(id)) );
        //    }

        //    return View(await drugname.ToListAsync());
        //}

        // GET: UsageCondition/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usageCondition = from m in _context.UsageConditions
                                 select m ;
            if (!String.IsNullOrEmpty(id))
            {
                usageCondition = usageCondition.Where(s => (s.DrugName!.Contains(id)));
            }
            if (usageCondition == null)
            {
                return NotFound();
            }

            return View( await usageCondition.ToListAsync());
        }

        // GET: UsageCondition/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsageCondition/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConditionId,Description,OtherDetails,DrugName")] UsageCondition usageCondition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usageCondition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usageCondition);
        }

        // GET: UsageCondition/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usageCondition = await _context.UsageConditions.FindAsync(id);
            if (usageCondition == null)
            {
                return NotFound();
            }
            return View(usageCondition);
        }

        // POST: UsageCondition/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConditionId,Description,OtherDetails,DrugName")] UsageCondition usageCondition)
        {
            if (id != usageCondition.ConditionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usageCondition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsageConditionExists(usageCondition.ConditionId))
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
            return View(usageCondition);
        }

        // GET: UsageCondition/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usageCondition = await _context.UsageConditions
                .FirstOrDefaultAsync(m => m.ConditionId == id);
            if (usageCondition == null)
            {
                return NotFound();
            }

            return View(usageCondition);
        }

        // POST: UsageCondition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usageCondition = await _context.UsageConditions.FindAsync(id);
            _context.UsageConditions.Remove(usageCondition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsageConditionExists(int id)
        {
            return _context.UsageConditions.Any(e => e.ConditionId == id);
        }
    }
}
