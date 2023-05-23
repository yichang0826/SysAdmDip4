using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace SysAdmDip4.Models.System
{
    public class Role
    {//腳色
        [Display(Name = "腳色 編號")][Key] public int Role_Id { get; set; }

        [Display(Name = "腳色 名稱")][Required]public string? Role_Name { get; set; }

        [Display(Name = "腳色 描述")][Required] public string? Role_Describe{ get; set; }

        [Display(Name = "腳色 功能列_數量")][Required] public int? Role_FunctionIdCount { get; set; }

        //[Display(Name = "腳色 功能列")][Required]public List<int>? Role_FunctionIdList { get; set; }

        [Display(Name = "腳色 功能列")]public List<RoleFunction> RoleFunctions { get; set; } // 增加關聯屬性

    }

    public class RoleFunction
    {
        [Key]public int RoleFunction_Id { get; set; }

        public int RoleId { get; set; }

        public int FunctionId { get; set; }

        public Role Role { get; set; } // 增加關聯屬性
    }
}
