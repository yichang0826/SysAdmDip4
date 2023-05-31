using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SysAdmDip4.Models.System;
using SysAdmDip4.Models.Article;

namespace SysAdmDip4.Data
{
    public class SysAdmDip4Context : DbContext
    {
        public SysAdmDip4Context(DbContextOptions<SysAdmDip4Context> options)
            : base(options)
        {
        }

        public DbSet<SysAdmDip4.Models.System.Member> Member { get; set; } = default!;

        public DbSet<SysAdmDip4.Models.System.Role>? Role { get; set; }

        public DbSet<SysAdmDip4.Models.System.RoleFunction>? RoleFunction { get; set; }

        public DbSet<SysAdmDip4.Models.System.Function>? Function { get; set; }

        public DbSet<SysAdmDip4.Models.Article.Knowlege>? Knowlege { get; set; }

        public DbSet<SysAdmDip4.Models.Article.Classify>? Classify { get; set; }

        public DbSet<SysAdmDip4.Models.Article.Comment>? Comment { get; set; }

        public DbSet<SysAdmDip4.Models.System.ExternalLink>? ExternalLink { get; set; }
    }
}
