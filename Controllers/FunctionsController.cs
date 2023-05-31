using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SysAdmDip4.Data;
using SysAdmDip4.Models.System;

namespace SysAdmDip4.Controllers
{
    //[Authorize]
    //[TypeFilter(typeof(CustomAuthorizationFilter))]
    public class FunctionsController : Controller
    {
        private readonly SysAdmDip4Context _context;

        public FunctionsController(SysAdmDip4Context context)
        {
            _context = context;
        }

        // GET: Functions
        public async Task<IActionResult> Index()
        {
              return _context.Function != null ? 
                          View(await _context.Function.ToListAsync()) :
                          Problem("Entity set 'SysAdmDip4Context.Function'  is null.");
        }

        // GET: Functions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Function == null)
            {
                return NotFound();
            }

            var function = await _context.Function
                .FirstOrDefaultAsync(m => m.Function_Id == id);
            if (function == null)
            {
                return NotFound();
            }

            return View(function);
        }

        // GET: Functions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Functions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Function_Id,Function_Name,Function_Controller,Function_Page,Function_Describe,Function_Active")] Function function)
        {
            try
            {
                function.Function_CreaterId = _context.Member.FirstOrDefault(m => m.Member_Name == User.Identity.Name)?.Member_Id ?? 1;
                function.Function_CreateDate = DateTime.Now;
                _context.Add(function);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        // GET: Functions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Function == null)
            {
                return NotFound();
            }

            var function = await _context.Function.FindAsync(id);
            if (function == null)
            {
                return NotFound();
            }
            return View(function);
        }

        // POST: Functions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Function_Id,Function_Name,Function_Controller,Function_Page,Function_Describe,Function_Active,Function_CreaterId,Function_CreateDate")] Function function)
        {
            if (id != function.Function_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(function);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FunctionExists(function.Function_Id))
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
            return View(function);
        }

        // GET: Functions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Function == null)
            {
                return NotFound();
            }

            var function = await _context.Function
                .FirstOrDefaultAsync(m => m.Function_Id == id);
            if (function == null)
            {
                return NotFound();
            }

            return View(function);
        }

        // POST: Functions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Function == null)
            {
                return Problem("Entity set 'SysAdmDip4Context.Function'  is null.");
            }
            var function = await _context.Function.FindAsync(id);
            if (function != null)
            {
                _context.Function.Remove(function);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FunctionExists(int id)
        {
          return (_context.Function?.Any(e => e.Function_Id == id)).GetValueOrDefault();
        }
    }
}
