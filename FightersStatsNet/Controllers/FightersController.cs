using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FightersStatsNet.Data;
using FightersStatsNet.Models;
using Microsoft.AspNetCore.Authorization;

namespace FightersStatsNet.Controllers
{
    [Authorize]
    public class FightersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FightersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fighters
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Fighters.Include(f => f.Game);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Fighters/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fighters == null)
            {
                return NotFound();
            }

            var fighter = await _context.Fighters
                .Include(f => f.Game)
                .FirstOrDefaultAsync(m => m.FighterId == id);
            if (fighter == null)
            {
                return NotFound();
            }

            return View(fighter);
        }

        // GET: Fighters/Create
        public IActionResult Create()
        {
            ViewData["GameId"] = new SelectList(_context.Game, "GameId", "Name");
            return View();
        }

        // POST: Fighters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FighterId,Name,Gender,PlayStyle,SkillLevel,Strengths,Weaknesses,GameId")] Fighter fighter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fighter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameId"] = new SelectList(_context.Game, "GameId", "Name", fighter.GameId);
            return View(fighter);
        }

        // GET: Fighters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fighters == null)
            {
                return NotFound();
            }

            var fighter = await _context.Fighters.FindAsync(id);
            if (fighter == null)
            {
                return NotFound();
            }
            ViewData["GameId"] = new SelectList(_context.Game, "GameId", "Name", fighter.GameId);
            return View(fighter);
        }

        // POST: Fighters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FighterId,Name,Gender,PlayStyle,SkillLevel,Strengths,Weaknesses,GameId")] Fighter fighter)
        {
            if (id != fighter.FighterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fighter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FighterExists(fighter.FighterId))
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
            ViewData["GameId"] = new SelectList(_context.Game, "GameId", "Name", fighter.GameId);
            return View(fighter);
        }

        // GET: Fighters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fighters == null)
            {
                return NotFound();
            }

            var fighter = await _context.Fighters
                .Include(f => f.Game)
                .FirstOrDefaultAsync(m => m.FighterId == id);
            if (fighter == null)
            {
                return NotFound();
            }

            return View(fighter);
        }

        // POST: Fighters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fighters == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Fighters'  is null.");
            }
            var fighter = await _context.Fighters.FindAsync(id);
            if (fighter != null)
            {
                _context.Fighters.Remove(fighter);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FighterExists(int id)
        {
          return _context.Fighters.Any(e => e.FighterId == id);
        }
    }
}
