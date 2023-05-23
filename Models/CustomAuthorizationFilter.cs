using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SysAdmDip4.Data;
using Microsoft.EntityFrameworkCore;

public class CustomAuthorizationFilter : IAsyncAuthorizationFilter
{
    private readonly SysAdmDip4Context _context;

    public CustomAuthorizationFilter(SysAdmDip4Context context)
    {
        _context = context;
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        // 檢查用戶是否已驗證
        if (!context.HttpContext.User.Identity.IsAuthenticated)
        {
            // 如果用戶未驗證，重定向到登入頁面或返回 401 未授權狀態碼
            context.Result = new ChallengeResult();
            return;
        }

        // 獲取用戶名稱
        string userName = context.HttpContext.User.Identity.Name;

        // 根據用戶名稱查詢對應的成員
        var member = await _context.Member.FirstOrDefaultAsync(m => m.Member_Name == userName);

        if (member == null)
        {
            // 如果成員不存在，返回 401 未授權狀態碼
            context.Result = new UnauthorizedResult();
            return;
        }

        // 根據成員的角色 ID 查詢對應的角色
        var role = await _context.Role.Include(r => r.RoleFunctions).FirstOrDefaultAsync(r => r.Role_Id == member.Member_RoleId);

        if (role == null)
        {
            // 如果角色不存在，返回 401 未授權狀態碼
            context.Result = new UnauthorizedResult();
            return;
        }

        // 獲取角色所擁有的功能 ID 列表
        var functionIds = role.RoleFunctions.Select(rf => rf.FunctionId).ToList();

        // 獲取功能 ID 列表對應的功能名稱
        var functions = await _context.Function
            .Where(f => functionIds.Contains(f.Function_Id))
            .Select(f => f.Function_Name)
            .ToListAsync();

        // 獲取當前 Action 的路由值（Controller 和 Action 名稱）
        string controllerName = context.RouteData.Values["controller"].ToString();
        string actionName = context.RouteData.Values["action"].ToString();

        // 檢查當前 Action 的路由值是否存在於功能名稱列表中
        if (!functions.Any(f => f.Equals($"/{controllerName}/{actionName}", StringComparison.OrdinalIgnoreCase)))
        {
            // 如果當前 Action 不在功能名稱列表中，返回 403 禁止狀態碼
            context.Result = new ForbidResult();
            return;
        }
    }
}
