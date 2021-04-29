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
    public class EmployeesController : Controller
    {
        private readonly DataContexInCh _context;

        public EmployeesController(DataContexInCh context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
			#region Test
			var relations = await _context.EmplSkills.ToListAsync();
            var skils = await _context.Skills.ToListAsync();
            var employees = await _context.Employees.ToListAsync();//Include(relations)

            //var rls= relations.

            foreach (var emp in employees)
            {
                //var emsk = relations.Select(x => x.SkillID).Where(y=>y.);
                var emsk = relations.Where(y => y.EmplID == emp.ID).Select(y => y.SkillID).ToList();
                foreach (var sk in emsk)
                {
                    var emsksl = skils.Where(x => x.ID == sk).Select(y => y.Name).ToList();


                }



                //Console.Out.WriteLine(emsksl);
            }

            //var ilists = _context.Employees.GroupJoin(
            //    _context.EmplSkills, e => e.ID, r => r.EmplID, (e, r) => new EmplSkills{
            //        EmplID=e.ID,
            //        SkillID=r.SkillID,

            //    }
            //    ).GroupJoin(
            //     _context.Skills, r => r.SkillID, rs => rs.ID, (sk, r) => new Employees
            //     {

            //     }
            //    );

            //var ksld= _context.Skills.GroupJoin(
            //    _context.EmplSkills, sk => sk.ID, rs => rs.SkillID, (sk, rs) => new { sk, rs }
            //    ).GroupJoin(
            //     _context.Employees, e => e., r => r.EmplID, (e, r) => new { e, r }
            //    )

            //Skills=_context.Skills.Select()
            //var ilists = _context.Employees.Join(
            //	_context.EmplSkills, e => e.ID, r => r.EmplID,
            //	//_context.Skills,e=>e.
            //	(e, r) => new 
            //	{e,r}
            //	).Join(
            //             _context.Skills, sk=>sk.
            //             )

            //var papa = await _context.Employees.Join(
            //	_context.EmplSkills,
            //	emplid => emplid.ID,
            //	relsk => relsk.EmplID,
            //	(emplid, relsk) => new Employees
            //	(
            //		ID = emplid.ID,
            //		Name = emplid.Name,
            //		Surname = emplid.Surname,
            //		PersonalDetails = emplid.PersonalDetails
            //		)
            //	).Join(
            //	_context.Skills,
            //	h => h.ID,

            //    )
            #endregion
            var papaki = await (
                          //select new Em{ }
                          from em in _context.Employees
                          join rk in _context.EmplSkills on em.ID equals rk.EmplID
                          join rs in _context.Skills on rk.SkillID equals rs.ID
                          select new Employees
                          {
                              ID = em.ID,
                              Name = em.Name,
                              Surname = em.Surname,
                              PersonalDetails = em.PersonalDetails,
                              Skills = rs.Name

                              //Skills= rs.Name
                          }

                ).ToListAsync();

           // var fnsl = papaki.Select(x => x.ID).ToList();

           // var kk=await _context

            //var emp=await _context.Employees.Include(x=>x.)
            //return View(await _context.Employees.ToListAsync());
            return View( papaki);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employees = await (
                         //select new Em{ }
                         from em in _context.Employees
                         join rk in _context.EmplSkills on em.ID equals rk.EmplID
                         join rs in _context.Skills on rk.SkillID equals rs.ID
                         where em.ID==id
                         select new Employees
                         {
                             ID = em.ID,
                             Name = em.Name,
                             Surname = em.Surname,
                             PersonalDetails = em.PersonalDetails,
                             Skills = rs.Name

                              //Skills= rs.Name
                          }

               ).FirstOrDefaultAsync();

           // var employees = await _context.Employees
			//	.FirstOrDefaultAsync(m => m.ID == id);
			//var skills = await _context.EmplSkills.Select(sk => sk.EmplID == employees.ID);

			//var employees= await _context.Employees.Join(_context.EmplSkills,e=>e.)
			if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Surname,PersonalDetails")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employees);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var employees = await _context.Employees.FindAsync(id);
            if (employees == null)
            {
                return NotFound();
            }
            return View(employees);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Surname,PersonalDetails")] Employees employees)
        {


            if (id != employees.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeesExists(employees.ID))
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
            return View(employees);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employees = await _context.Employees
                .FirstOrDefaultAsync(m => m.ID == id);
            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employees = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employees);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeesExists(int id)
        {
            return _context.Employees.Any(e => e.ID == id);
        }
    }
}
