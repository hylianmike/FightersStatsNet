using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FightersStatsNet.Data;
using FightersStatsNet.Models;

namespace FightersStatsNet.Controllers
{
    public class AttacksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttacksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Attacks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Attacks.Include(a => a.Fighter);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Attacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Attacks == null)
            {
                return NotFound();
            }

            var attack = await _context.Attacks
                .Include(a => a.Fighter)
                .FirstOrDefaultAsync(m => m.AttackId == id);
            if (attack == null)
            {
                return NotFound();
            }

            return View(attack);
        }

        // GET: Attacks/Create
        public IActionResult Create()
        {
            ViewData["FighterId"] = new SelectList(_context.Fighters, "FighterId", "Name");
            return View();
        }

        // POST: Attacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttackId,Name,ButtonInput,FighterId")] Attack attack)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FighterId"] = new SelectList(_context.Fighters, "FighterId", "Name", attack.FighterId);
            return View(attack);
        }

        // GET: Attacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Attacks == null)
            {
                return NotFound();
            }

            var attack = await _context.Attacks.FindAsync(id);
            if (attack == null)
            {
                return NotFound();
            }
            ViewData["FighterId"] = new SelectList(_context.Fighters, "FighterId", "Name", attack.FighterId);
            return View(attack);
        }

        // POST: Attacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttackId,Name,ButtonInput,FighterId")] Attack attack)
        {
            if (id != attack.AttackId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttackExists(attack.AttackId))
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
            ViewData["FighterId"] = new SelectList(_context.Fighters, "FighterId", "Name", attack.FighterId);
            return View(attack);
        }

        // GET: Attacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Attacks == null)
            {
                return NotFound();
            }

            var attack = await _context.Attacks
                .Include(a => a.Fighter)
                .FirstOrDefaultAsync(m => m.AttackId == id);
            if (attack == null)
            {
                return NotFound();
            }

            return View(attack);
        }

        // POST: Attacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Attacks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Attacks'  is null.");
            }
            var attack = await _context.Attacks.FindAsync(id);
            if (attack != null)
            {
                _context.Attacks.Remove(attack);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttackExists(int id)
        {
          return _context.Attacks.Any(e => e.AttackId == id);
        }
    }
}
