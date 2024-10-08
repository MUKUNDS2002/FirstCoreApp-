using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstCoreApp.Data;
using FirstCoreApp.Models;

namespace FirstCoreApp.Controllers
{
    public class StudentDatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentData.ToListAsync());
        }

        // GET: StudentDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentData = await _context.StudentData
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentData == null)
            {
                return NotFound();
            }

            return View(studentData);
        }

        // GET: StudentDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,Name,Branch,Section,Gender")] StudentData studentData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentData);
        }

        // GET: StudentDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentData = await _context.StudentData.FindAsync(id);
            if (studentData == null)
            {
                return NotFound();
            }
            return View(studentData);
        }

        // POST: StudentDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,Name,Branch,Section,Gender")] StudentData studentData)
        {
            if (id != studentData.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentDataExists(studentData.StudentId))
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
            return View(studentData);
        }

        // GET: StudentDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentData = await _context.StudentData
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentData == null)
            {
                return NotFound();
            }

            return View(studentData);
        }

        // POST: StudentDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentData = await _context.StudentData.FindAsync(id);
            if (studentData != null)
            {
                _context.StudentData.Remove(studentData);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentDataExists(int id)
        {
            return _context.StudentData.Any(e => e.StudentId == id);
        }
    }
}
