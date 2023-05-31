using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SysAdmDip4.Data;
using SysAdmDip4.Models.System;
using SysAdmDip4.Models.ViewModel;

namespace SysAdmDip4.Controllers
{
    //[Authorize]
    //[TypeFilter(typeof(CustomAuthorizationFilter))]
    public class RolesController : Controller
    {
        private readonly SysAdmDip4Context _context;

        public RolesController(SysAdmDip4Context context)
        {
            _context = context;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
            return _context.Role != null ?
                        View(await _context.Role.ToListAsync()) :
                        Problem("Entity set 'SysAdmDip4Context.Role'  is null.");
        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //var member = await _context.Member.Include(m => m.Member_Role).FirstOrDefaultAsync(m => m.Member_Id == id);
            var rolefunctions = _context.RoleFunction.Where(m => m.RoleId == id).ToList();
            var roles = _context.Role.Include(m => m.RoleFunctions).FirstOrDefault(m => m.Role_Id == id);
            if (rolefunctions != null)
            {
                var model = new RoleDetailViewModel
                {
                    role = roles,
                    rolefunctions = rolefunctions
                };
                return View(model);
            }
            return NotFound();
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            var model = new RoleCreateViewModel
            {
                role = new Role(),
                functions = _context.Function.ToList()
            };
            return View(model);
        }

        // POST: Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string roleName, string roleDescribe, List<int> selectedFunctions)
        {
            try
            {
                Role role = new Role
                {
                    Role_Name = roleName,
                    Role_Describe = roleDescribe,
                    Role_FunctionIdCount = 0,
                    RoleFunctions = new List<RoleFunction> { },
                };
                foreach (var function in selectedFunctions)
                {
                    var roleFunction = new RoleFunction
                    {
                        RoleId = role.Role_Id,
                        FunctionId = function
                    };
                    role.RoleFunctions.Add(roleFunction);
                }
                role.Role_FunctionIdCount = role.RoleFunctions.Count;
                _context.Add(role);
                await _context.SaveChangesAsync();
                if (_context.Role.FirstOrDefault(m => m.Role_Id == role.Role_Id).RoleFunctions != null)
                {
                    return RedirectToAction("Details", new { id = role.Role_Id });
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["Danger"] = ex;
                return View();
            }
        }


        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                var role = _context.Role?.Include(m => m.RoleFunctions).First(m => m.Role_Id == id);
                return View(role);
            }
            catch (Exception ex)
            {
                ViewData["Danger"] = ex;
                return View();
            }
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Role_Id,Role_Name,Role_Describe")] Role role, List<int> selectedFunctions)
        {
            if (id != role.Role_Id)
            {
                return NotFound();
            }

            try
            {
                var existingRole = _context.Role.Include(r => r.RoleFunctions).FirstOrDefault(r => r.Role_Id == id);

                if (existingRole == null) { return NotFound(); }

                // 移除不再選取的 RoleFunction
                foreach (var roleFunction in existingRole.RoleFunctions.ToList())
                {
                    if (!selectedFunctions.Contains(roleFunction.FunctionId))
                    {
                        existingRole.RoleFunctions.Remove(roleFunction);
                    }
                }

                // 新增新選取的 RoleFunction
                foreach (var functionId in selectedFunctions)
                {
                    if (!existingRole.RoleFunctions.Any(rf => rf.FunctionId == functionId))
                    {
                        existingRole.RoleFunctions.Add(new RoleFunction { RoleId = id, FunctionId = functionId });
                    }
                }
                existingRole.Role_FunctionIdCount = existingRole.RoleFunctions.Count;
                _context.Update(existingRole);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(role.Role_Id))
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

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Role == null)
            {
                return NotFound();
            }

            var role = await _context.Role
                .FirstOrDefaultAsync(m => m.Role_Id == id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Role == null)
            {
                return Problem("Entity set 'SysAdmDip4Context.Role'  is null.");
            }
            var role = await _context.Role.FindAsync(id);
            if (role != null)
            {
                _context.Role.Remove(role);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleExists(int id)
        {
            return (_context.Role?.Any(e => e.Role_Id == id)).GetValueOrDefault();
        }
    }
}
