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
    public class NewDrugTrialController : Controller
    {
        private readonly IdentityModel _context;

        public NewDrugTrialController(IdentityModel context)
        {
            _context = context;
        }

        // GET: NewDrugTrial
        public async Task<IActionResult> Index()
        {
            var identityModel = _context.NewDrugTrials.Include(n => n.Drug).Include(n => n.Employee).Include(n => n.Patient);
            return View(await identityModel.ToListAsync());
        }

        // GET: NewDrugTrial/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newDrugTrial = await _context.NewDrugTrials
                .Include(n => n.Drug)
                .Include(n => n.Employee)
                .Include(n => n.Patient)
                .FirstOrDefaultAsync(m => m.TrialId == id);
            if (newDrugTrial == null)
            {
                return NotFound();
            }

            return View(newDrugTrial);
        }

        // GET: NewDrugTrial/Create
        public IActionResult Create()
        {
            ViewData["DrugId"] = new SelectList(_context.Drugs, "DrugId", "ChemicalAnalysis");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "DepartmentName");
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "Address");
            return View();
        }

        // POST: NewDrugTrial/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrialId,StartDate,EndDate,PurposeOfTrial,EmployeeId,PatientId,DrugId,TrialResults,TrialStatus")] NewDrugTrial newDrugTrial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newDrugTrial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DrugId"] = new SelectList(_context.Drugs, "DrugId", "ChemicalAnalysis", newDrugTrial.DrugId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "DepartmentName", newDrugTrial.EmployeeId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "Address", newDrugTrial.PatientId);
            return View(newDrugTrial);
        }

        // GET: NewDrugTrial/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newDrugTrial = await _context.NewDrugTrials.FindAsync(id);
            if (newDrugTrial == null)
            {
                return NotFound();
            }
            ViewData["DrugId"] = new SelectList(_context.Drugs, "DrugId", "ChemicalAnalysis", newDrugTrial.DrugId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "DepartmentName", newDrugTrial.EmployeeId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "Address", newDrugTrial.PatientId);
            return View(newDrugTrial);
        }

        // POST: NewDrugTrial/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrialId,StartDate,EndDate,PurposeOfTrial,EmployeeId,PatientId,DrugId,TrialResults,TrialStatus")] NewDrugTrial newDrugTrial)
        {
            if (id != newDrugTrial.TrialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newDrugTrial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewDrugTrialExists(newDrugTrial.TrialId))
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
            ViewData["DrugId"] = new SelectList(_context.Drugs, "DrugId", "ChemicalAnalysis", newDrugTrial.DrugId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "DepartmentName", newDrugTrial.EmployeeId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "Address", newDrugTrial.PatientId);
            return View(newDrugTrial);
        }

        // GET: NewDrugTrial/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newDrugTrial = await _context.NewDrugTrials
                .Include(n => n.Drug)
                .Include(n => n.Employee)
                .Include(n => n.Patient)
                .FirstOrDefaultAsync(m => m.TrialId == id);
            if (newDrugTrial == null)
            {
                return NotFound();
            }

            return View(newDrugTrial);
        }

        // POST: NewDrugTrial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newDrugTrial = await _context.NewDrugTrials.FindAsync(id);
            _context.NewDrugTrials.Remove(newDrugTrial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewDrugTrialExists(int id)
        {
            return _context.NewDrugTrials.Any(e => e.TrialId == id);
        }
    }
}
