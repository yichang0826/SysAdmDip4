using System.ComponentModel.DataAnnotations;

namespace SysAdmDip4.Models.System
{
    public class ExternalLink
    {
        [Key]public int Link_Id { get; set; }

        [Required]public string? Link_Name { get; set; }

        [Required]public string? Link_Url { get; set; }

        [Required]public bool? Link_IsActive { get; set; } = true;

        public DateTime? Link_CreateDate { get; set; }
    }
}
