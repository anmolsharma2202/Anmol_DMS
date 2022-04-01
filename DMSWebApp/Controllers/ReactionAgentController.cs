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
    public class ReactionAgentController : Controller
    {
        private readonly IdentityModel _context;

        public ReactionAgentController(IdentityModel context)
        {
            _context = context;
        }

        // GET: ReactionAgent
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReactionAgents.ToListAsync());
        }

        // GET: ReactionAgent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reactionAgent = await _context.ReactionAgents
                .FirstOrDefaultAsync(m => m.ReactionAgentId == id);
            if (reactionAgent == null)
            {
                return NotFound();
            }

            return View(reactionAgent);
        }

        // GET: ReactionAgent/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReactionAgent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReactionAgentId,ShortName,LongName,Description")] ReactionAgent reactionAgent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reactionAgent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reactionAgent);
        }

        // GET: ReactionAgent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reactionAgent = await _context.ReactionAgents.FindAsync(id);
            if (reactionAgent == null)
            {
                return NotFound();
            }
            return View(reactionAgent);
        }

        // POST: ReactionAgent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReactionAgentId,ShortName,LongName,Description")] ReactionAgent reactionAgent)
        {
            if (id != reactionAgent.ReactionAgentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reactionAgent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReactionAgentExists(reactionAgent.ReactionAgentId))
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
            return View(reactionAgent);
        }

        // GET: ReactionAgent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reactionAgent = await _context.ReactionAgents
                .FirstOrDefaultAsync(m => m.ReactionAgentId == id);
            if (reactionAgent == null)
            {
                return NotFound();
            }

            return View(reactionAgent);
        }

        // POST: ReactionAgent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reactionAgent = await _context.ReactionAgents.FindAsync(id);
            _context.ReactionAgents.Remove(reactionAgent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReactionAgentExists(int id)
        {
            return _context.ReactionAgents.Any(e => e.ReactionAgentId == id);
        }
    }
}
