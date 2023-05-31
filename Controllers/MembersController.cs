using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SysAdmDip4.Data;
using SysAdmDip4.Models.System;

namespace SysAdmDip4.Controllers
{
    //[Authorize]
    //[TypeFilter(typeof(CustomAuthorizationFilter))]
    public class MembersController : Controller
    {
        private readonly SysAdmDip4Context _context;

        public MembersController(SysAdmDip4Context context)
        {
            _context = context;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            //var sysAdmDip4Context = _context.Member.Include(m => m.Member_Role);
            //return View(await sysAdmDip4Context.ToListAsync());
            return View(await _context.Member.ToListAsync());
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            //var member = await _context.Member
            //    .Include(m => m.Member_Role)
            //.FirstOrDefaultAsync(m => m.Member_Id == id);
            var member = await _context.Member.FirstOrDefaultAsync(m => m.Member_Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            ViewData["Member_RoleId"] = new SelectList(_context.Set<Role>(), "Role_Id", "Role_Name");
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Member_Name,Member_Account,Member_Password,Member_Email,Member_RoleId,Member_Active")] Member member)
        {
            member.Member_CreaterId = _context.Member.FirstOrDefault(m => m.Member_Name == User.Identity.Name)?.Member_Id ?? 1;
            member.Member_CreateDate = DateTime.Now;
            try
            {
                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["Danger"] = ex;
                ViewData["Member_RoleId"] = new SelectList(_context.Set<Role>(), "Role_Id", "Role_Name", member.Member_RoleId);
                return View(member);
            }
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            ViewData["Member_RoleId"] = new SelectList(_context.Set<Role>(), "Role_Id", "Role_Name", member.Member_RoleId);
            await _context.SaveChangesAsync();
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Member_Id,Member_Name,Member_Account,Member_Password,Member_Email,Member_RoleId,Member_Active,Member_CreaterId")] Member member)
        {
            if (id != member.Member_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var excistmember = _context.Member.Find(id);
                    if (excistmember != null)
                    {
                        excistmember.Member_Name = member.Member_Name;
                        excistmember.Member_Account = member.Member_Account;
                        excistmember.Member_Password = member.Member_Password;
                        excistmember.Member_Email = member.Member_Email;
                        excistmember.Member_RoleId = member.Member_RoleId;
                        excistmember.Member_Active = member.Member_Active;
                    };
                    //_context.Entry(excistmember).State = EntityState.Modified;
                    //_context.Update(excistmember);

                    //_context.Attach(member);
                    //_context.Entry(member).State = EntityState.Modified;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.Member_Id))
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
            return View(member);
            //try
            //{
            //    var excistmember = _context.Member.FirstOrDefault(m => m.Member_Id == id);
            //    if (excistmember != null)
            //    {
            //        member.Member_CreaterId = excistmember.Member_CreaterId;
            //        member.Member_CreateDate = excistmember.Member_CreateDate;
            //    }
            //    _context.Update(member);
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!MemberExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            //return RedirectToAction(nameof(Index));
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                //.Include(m => m.Member_Role)
                .FirstOrDefaultAsync(m => m.Member_Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Member == null)
            {
                return Problem("Entity set 'SysAdmDip4Context.Member'  is null.");
            }
            var member = await _context.Member.FindAsync(id);
            if (member != null)
            {
                _context.Member.Remove(member);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
            return (_context.Member?.Any(e => e.Member_Id == id)).GetValueOrDefault();
        }
    }
}
