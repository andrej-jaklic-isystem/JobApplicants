using System;
using System.Collections.Generic;

namespace Test01.Data.Models.Ident
{
    public partial class AppRolesModules
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public DateTime Created { get; set; }
        public string Createdby { get; set; }
        public DateTime? Modified { get; set; }
        public string Modifiedby { get; set; }
        public int Version { get; set; }

        public virtual AppModules Module { get; set; }
        public virtual AppRoles Role { get; set; }
    }
}
