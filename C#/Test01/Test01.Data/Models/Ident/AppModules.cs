using System;
using System.Collections.Generic;

namespace Test01.Data.Models.Ident
{
    public partial class AppModules
    {
        public AppModules()
        {
            AppRolesModules = new HashSet<AppRolesModules>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string EncryptedSid { get; set; }
        public bool? Isactive { get; set; }
        public DateTime Created { get; set; }
        public string Createdby { get; set; }
        public DateTime? Modified { get; set; }
        public string Modifiedby { get; set; }
        public int Version { get; set; }

        public virtual ICollection<AppRolesModules> AppRolesModules { get; set; }
    }
}
