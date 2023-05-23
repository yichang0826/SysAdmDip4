using SysAdmDip4.Models.System;
using SysAdmDip4.Data;

namespace SysAdmDip4.Models.ViewModel
{
    public class RoleCreateViewModel
    {
        public Role? role { get; set; }

        public List<Function> functions { get; set; }
    }
}
