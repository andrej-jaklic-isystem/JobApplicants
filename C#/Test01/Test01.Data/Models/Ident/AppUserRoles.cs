using System;
using System.Collections.Generic;

namespace Test01.Data.Models.Ident
{
    public partial class AppUserRoles
    {
        public int Id { get; set; }
        public int Idappuser { get; set; }
        public int Idrole { get; set; }
        public bool? Isactive { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public DateTime Created { get; set; }
        public string Createdby { get; set; }
        public DateTime? Modified { get; set; }
        public string Modifiedby { get; set; }
        public int Version { get; set; }

        public virtual AppUsers IdappuserNavigation { get; set; }
        public virtual AppRoles IdroleNavigation { get; set; }
    }
}
