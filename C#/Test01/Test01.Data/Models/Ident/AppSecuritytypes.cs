using System;
using System.Collections.Generic;

namespace Test01.Data.Models.Ident
{
    public partial class AppSecuritytypes
    {
        public AppSecuritytypes()
        {
            AppUsers = new HashSet<AppUsers>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AppUsers> AppUsers { get; set; }
    }
}
