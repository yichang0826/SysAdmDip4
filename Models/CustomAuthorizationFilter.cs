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
        if (!context.HttpContext.User.Identity.IsAuthenticated)//檢查用戶是否已驗證
        {
            context.Result = new ChallengeResult();//如果用戶未驗證，重定向到登入頁面或返回 401 未授權狀態碼
            return;
        }

        string userName = context.HttpContext.User.Identity.Name;//獲取用戶名稱
        var member = await _context.Member.FirstOrDefaultAsync(m => m.Member_Name == userName);// 根據用戶名稱查詢對應的成員
        if (member == null)
        {
            context.Result = new UnauthorizedResult();// 如果成員不存在，返回 401 未授權狀態碼
            return;
        }

        var role = await _context.Role.Include(r => r.RoleFunctions).FirstOrDefaultAsync(r => r.Role_Id == member.Member_RoleId);// 根據成員的角色 ID 查詢對應的角色
        if (role == null)
        {
            context.Result = new UnauthorizedResult();// 如果角色不存在，返回 401 未授權狀態碼
            return;
        }

        var functionIds = role.RoleFunctions.Select(rf => rf.FunctionId).ToList();// 獲取角色所擁有的功能 ID 列表
        var functions = await _context.Function
            .Where(f => functionIds.Contains(f.Function_Id))
            .Select(f => f.Function_Describe)
            .ToListAsync();// 獲取功能 ID 列表對應的功能名稱

        // 獲取當前 Action 的路由值（Controller 和 Action 名稱）
        string controllerName = context.RouteData.Values["controller"].ToString();
        string actionName = context.RouteData.Values["action"].ToString();

        if (!functions.Any(f => f.Equals($"/{controllerName}/{actionName}", StringComparison.OrdinalIgnoreCase)))// 檢查當前 Action 的路由值是否存在於功能名稱列表中
        {
            context.Result = new ForbidResult();// 如果當前 Action 不在功能名稱列表中，返回 403 禁止狀態碼
            return;
        }
    }
}
