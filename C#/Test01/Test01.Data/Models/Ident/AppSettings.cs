using System;
using System.Collections.Generic;

namespace Test01.Data.Models.Ident
{
    public partial class AppSettings
    {
        public int Id { get; set; }
        public string Keyname { get; set; }
        public string Description { get; set; }
        public string Application { get; set; }
        public int? Idappuser { get; set; }
        public string Computername { get; set; }
        public string Value { get; set; }
        public string Defaultvalue { get; set; }
        public DateTime? Cdate { get; set; }
        public string Cuser { get; set; }

        public virtual AppUsers IdappuserNavigation { get; set; }
    }
}
