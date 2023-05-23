using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SysAdmDip4.Models.System
{
    public class Member
    {//人員
        [Display(Name = "人員 編號")][Key] public int Member_Id { get; set; }

        [Display(Name = "人員 名稱")][Required] public string? Member_Name { get; set; }

        [Display(Name = "人員 帳號")][Required] public string? Member_Account { get; set; }

        [Display(Name = "人員 密碼")][Required] public string? Member_Password { get; set; }

        //[Display(Name = "人員 頭貼_2進")][Required] public byte[]? Member_ImgByte { get; set; }

        //[Display(Name = "人員 頭貼_連結")][Required] public string? Member_ImgSrc { get; set; }

        [Display(Name = "人員 郵箱")][Required] public string? Member_Email { get; set; }

        [Display(Name = "人員 腳色_編號")][Required] public int? Member_RoleId { get; set; }

        //[Display(Name = "人員 腳色")][Required] public MemberRole? Member_Role { get; set; }

        [Display(Name = "人員 啟用")][Required] public int? Member_Active { get; set; }

        [Display(Name = "人員 創建者_編號")][Required] public int? Member_CreaterId { get; set; }

        [Display(Name = "人員 創建_日期")][Required] public DateTime? Member_CreateDate { get; set; }

        //[Required] public Role? Member_Role { get; set; }

        //[Display(Name = "人員 文章_串列")]public List<Article>? Articles { get; set; }

    }

    //public class MemberRole
    //{
    //    [Key]public int MemberRole_Id { get; set; }

    //    public int? MemberId { get; set; }

    //    public int? RoleId { get; set; }
    //}
}
