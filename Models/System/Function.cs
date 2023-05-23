using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SysAdmDip4.Models.System
{
    public class Function
    {//功能
        [Display(Name = "功能 編號")][Key] public int Function_Id { get; set; }

        [Display(Name = "功能 名稱")][Required] public string? Function_Name { get; set; }

        [Display(Name = "功能 控制器")][Required] public string? Function_Controller { get; set; }

        [Display(Name = "功能 頁面")][Required] public string? Function_Page { get; set; }

        [Display(Name = "功能 描述")][Required] public string? Function_Describe { get; set; }

        [Display(Name = "功能 啟用")][Required] public int? Function_Active { get; set; }

        [Display(Name = "功能 創建者_編號")][Required] public int? Function_CreaterId { get; set; }

        [Display(Name = "功能 創建_日期")][Required] public DateTime? Function_CreateDate { get; set; }
    }
}
