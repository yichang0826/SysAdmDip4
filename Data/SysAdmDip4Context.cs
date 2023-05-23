using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SysAdmDip4.Models.System;

namespace SysAdmDip4.Data
{
    public class SysAdmDip4Context : DbContext
    {
        public SysAdmDip4Context (DbContextOptions<SysAdmDip4Context> options)
            : base(options)
        {
        }

        public DbSet<SysAdmDip4.Models.System.Member> Member { get; set; } = default!;

        public DbSet<SysAdmDip4.Models.System.Role>? Role { get; set; }

        public DbSet<SysAdmDip4.Models.System.RoleFunction>? RoleFunction { get; set; }

        public DbSet<SysAdmDip4.Models.System.Function>? Function { get; set; }
    }
}
