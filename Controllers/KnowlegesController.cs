using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SysAdmDip4.Data;
using SysAdmDip4.Models.Article;

namespace SysAdmDip4.Controllers
{
    public class KnowlegesController : Controller
    {
        private readonly SysAdmDip4Context _context;

        public KnowlegesController(SysAdmDip4Context context)
        {
            _context = context;
        }

        // GET: Knowleges
        public async Task<IActionResult> Index()
        {
            return _context.Knowlege != null ?
                        View(await _context.Knowlege.Include(m => m.Knowlege_Comment).ToListAsync()) :
                        Problem("Entity set 'SysAdmDip4Context.Knowlege'  is null.");
        }

        // GET: Knowleges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Knowlege == null)
            {
                return NotFound();
            }

            var knowlege = await _context.Knowlege
                .FirstOrDefaultAsync(m => m.Knowlege_Id == id);
            if (knowlege == null)
            {
                return NotFound();
            }

            return View(knowlege);
        }

        // GET: Knowleges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Knowleges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Knowlege_Id,Knowlege_Title,Knowlege_Author,Knowlege_Introduction,Knowlege_Content,Knowlege_FileSrc,Knowlege_Transparency,Knowlege_Content,Knowlege_CreaterId,Knowlege_CreateDate")] Knowlege knowlege, string KnowlegeContent)
        {
            //catch the user name
            var member = _context.Member.FirstOrDefault(m => m.Member_Name == User.Identity.Name);
            string content = knowlege.Knowlege_Content ?? "Fuck you";
            if (member is not null)
            {
                //knowlege.Knowlege_CreaterId = _context.Member.First(m => m.Member_Name == User.Identity.Name).Member_Id;
                knowlege.Knowlege_CreaterId = member.Member_Id;
                knowlege.Knowlege_CreateDate = DateTime.Now;
                knowlege.Knowlege_FileSrc ??= "0";
                knowlege.Knowlege_Content = content;
                _context.Add(knowlege);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Knowleges");
            }
            return View(knowlege);
        }

        // GET: Knowleges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Knowlege == null)
            {
                return NotFound();
            }

            var knowlege = await _context.Knowlege.FindAsync(id);
            if (knowlege == null)
            {
                return NotFound();
            }
            return View(knowlege);
        }

        // POST: Knowleges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Knowlege_Id,Knowlege_Title,Knowlege_Author,Knowlege_Introduction,Knowlege_Content,Knowlege_FileSrc,Knowlege_Transparency,Knowlege_CreaterId,Knowlege_CreateDate")] Knowlege knowlege)
        {
            if (id != knowlege.Knowlege_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(knowlege);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KnowlegeExists(knowlege.Knowlege_Id))
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
            return View(knowlege);
        }

        // GET: Knowleges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Knowlege == null)
            {
                return NotFound();
            }

            var knowlege = await _context.Knowlege
                .FirstOrDefaultAsync(m => m.Knowlege_Id == id);
            if (knowlege == null)
            {
                return NotFound();
            }

            return View(knowlege);
        }

        // POST: Knowleges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Knowlege == null)
            {
                return Problem("Entity set 'SysAdmDip4Context.Knowlege'  is null.");
            }
            var knowlege = await _context.Knowlege.FindAsync(id);
            if (knowlege != null)
            {
                _context.Knowlege.Remove(knowlege);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KnowlegeExists(int id)
        {
            return (_context.Knowlege?.Any(e => e.Knowlege_Id == id)).GetValueOrDefault();
        }
    }
}
