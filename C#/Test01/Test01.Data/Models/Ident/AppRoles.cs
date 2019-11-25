using System;
using System.Collections.Generic;

namespace Test01.Data.Models.Ident
{
    public partial class AppRoles
    {
        public AppRoles()
        {
            AppRolesModules = new HashSet<AppRolesModules>();
            AppUserRoles = new HashSet<AppUserRoles>();
        }

        public int Id { get; set; }
        public string Rolename { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string Createdby { get; set; }
        public DateTime? Modified { get; set; }
        public string Modifiedby { get; set; }
        public int Version { get; set; }

        public virtual ICollection<AppRolesModules> AppRolesModules { get; set; }
        public virtual ICollection<AppUserRoles> AppUserRoles { get; set; }
    }
}
