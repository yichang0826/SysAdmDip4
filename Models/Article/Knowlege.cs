using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SysAdmDip4.Models.Article
{
    public class Knowlege
    {
        [Key]public int Knowlege_Id { get; set; }

        [Display(Name ="文章 標題")][Required]public string? Knowlege_Title { get; set; }

        [Display(Name = "文章 作者_名稱")][Required] public string? Knowlege_Author { get; set; }

        [Display(Name = "文章 分類_標籤_串列")] public List<Classify> Knowlege_Classify { get; set; } = new List<Classify>();

        [Display(Name = "文章 評論_串列")] public List<Comment> Knowlege_Comment { get; set; } = new List<Comment>();

        [Display(Name = "文章 簡介")][Required]public string? Knowlege_Introduction { get; set; }

        [Display(Name = "文章 文字")] public string? Knowlege_Content { get; set; }

        [Display(Name = "文章 檔案_連結")] public string? Knowlege_FileSrc { get; set; }

        [Display(Name = "文章 透明度")][Required] public int? Knowlege_Transparency { get; set; }//transparency 透明度
        //1:Draft 2:Private 3:Public

        [Display(Name = "文章 觀看數")] public int? Knowlege_ViewCount { get; set; } = 0;

        [Display(Name = "文章 創建_編號")]public int? Knowlege_CreaterId { get; set; }

        [Display(Name = "文章 創建_日期")]public DateTime? Knowlege_CreateDate { get; set; }
    }
    public class Classify //分類
    {
        [Key]public int Classify_Id { get; set; }//分類編號

        [Required]public string? Classify_Name { get; set; }//分類名稱

        public Knowlege? Knowlege { get; set; }//串接屬性
    }
    public class Comment//評論
    {
        [Key]public int Comment_Id { get; set; }//評論編號

        [Required] public string? Comment_AuthorId { get; set; }//評論作者編號

        [Required]public string? Comment_Characteristic { get; set; }//評論性質

        public string? Comment_Text { get; set; } = "";//評論文字

        public Knowlege? Knowlege { get; set; }//串接屬性
    }
}
