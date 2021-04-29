using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InikoChallenge.Models.Data;
using InikoChallenge.Models.Data.Contex;

namespace InikoChallenge.Controllers
{
    public class EmplSkillsController : Controller
    {
        private readonly DataContexInCh _context;

        public EmplSkillsController(DataContexInCh context)
        {
            _context = context;
        }

        // GET: EmplSkills
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmplSkills.ToListAsync());
        }

        // GET: EmplSkills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emplSkills = await _context.EmplSkills
                .FirstOrDefaultAsync(m => m.RelationID == id);
            if (emplSkills == null)
            {
                return NotFound();
            }

            return View(emplSkills);
        }

        // GET: EmplSkills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmplSkills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RelationID,EmplID,SkillID")] EmplSkills emplSkills)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emplSkills);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emplSkills);
        }

        // GET: EmplSkills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emplSkills = await _context.EmplSkills.FindAsync(id);
            if (emplSkills == null)
            {
                return NotFound();
            }
            return View(emplSkills);
        }

        // POST: EmplSkills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RelationID,EmplID,SkillID")] EmplSkills emplSkills)
        {
            if (id != emplSkills.RelationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emplSkills);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmplSkillsExists(emplSkills.RelationID))
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
            return View(emplSkills);
        }

        // GET: EmplSkills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emplSkills = await _context.EmplSkills
                .FirstOrDefaultAsync(m => m.RelationID == id);
            if (emplSkills == null)
            {
                return NotFound();
            }

            return View(emplSkills);
        }

        // POST: EmplSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emplSkills = await _context.EmplSkills.FindAsync(id);
            _context.EmplSkills.Remove(emplSkills);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmplSkillsExists(int id)
        {
            return _context.EmplSkills.Any(e => e.RelationID == id);
        }
    }
}
