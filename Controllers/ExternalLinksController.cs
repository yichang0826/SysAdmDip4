using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SysAdmDip4.Data;
using SysAdmDip4.Models.System;

namespace SysAdmDip4.Controllers
{
    public class ExternalLinksController : Controller
    {
        private readonly SysAdmDip4Context _context;

        public ExternalLinksController(SysAdmDip4Context context)
        {
            _context = context;
        }

        // GET: ExternalLinks
        public async Task<IActionResult> Index()
        {
              return _context.ExternalLink != null ? 
                          View(await _context.ExternalLink.ToListAsync()) :
                          Problem("Entity set 'SysAdmDip4Context.ExternalLink'  is null.");
        }

        // GET: ExternalLinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExternalLink == null)
            {
                return NotFound();
            }

            var externalLink = await _context.ExternalLink
                .FirstOrDefaultAsync(m => m.Link_Id == id);
            if (externalLink == null)
            {
                return NotFound();
            }

            return View(externalLink);
        }

        // GET: ExternalLinks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExternalLinks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Link_Id,Link_Name,Link_Url,Link_IsActive")] ExternalLink externalLink)
        {
            if (ModelState.IsValid)
            {
                externalLink.Link_CreateDate = DateTime.Now;
                _context.Add(externalLink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(externalLink);
        }

        // GET: ExternalLinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExternalLink == null)
            {
                return NotFound();
            }

            var externalLink = await _context.ExternalLink.FindAsync(id);
            if (externalLink == null)
            {
                return NotFound();
            }
            return View(externalLink);
        }

        // POST: ExternalLinks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Link_Id,Link_Name,Link_Url,Link_IsActive,Link_CreateDate")] ExternalLink externalLink)
        {
            if (id != externalLink.Link_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(externalLink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExternalLinkExists(externalLink.Link_Id))
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
            return View(externalLink);
        }

        // GET: ExternalLinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExternalLink == null)
            {
                return NotFound();
            }

            var externalLink = await _context.ExternalLink
                .FirstOrDefaultAsync(m => m.Link_Id == id);
            if (externalLink == null)
            {
                return NotFound();
            }

            return View(externalLink);
        }

        // POST: ExternalLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExternalLink == null)
            {
                return Problem("Entity set 'SysAdmDip4Context.ExternalLink'  is null.");
            }
            var externalLink = await _context.ExternalLink.FindAsync(id);
            if (externalLink != null)
            {
                _context.ExternalLink.Remove(externalLink);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExternalLinkExists(int id)
        {
          return (_context.ExternalLink?.Any(e => e.Link_Id == id)).GetValueOrDefault();
        }
    }
}
