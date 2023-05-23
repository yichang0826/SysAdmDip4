using SysAdmDip4.Models.System;

namespace SysAdmDip4.Models.ViewModel
{
    public class RoleDetailViewModel
    {
        public Role role { get; set; }

        public List<RoleFunction> rolefunctions { get; set; }
    }
}
