using System;
using System.Collections.Generic;

namespace Test01.Data.Models.Ident
{
    public partial class AppSyslog
    {
        public int Id { get; set; }
        public int EventtypeId { get; set; }
        public DateTime Eventdate { get; set; }
        public int? AppUserId { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Emailto { get; set; }
        public bool? IsVisible { get; set; }
        public string Cuser { get; set; }
        public DateTime Cdate { get; set; }
        public string Muser { get; set; }
        public DateTime? Mdate { get; set; }

        public virtual AppUsers AppUser { get; set; }
        public virtual Eventtype Eventtype { get; set; }
    }
}
