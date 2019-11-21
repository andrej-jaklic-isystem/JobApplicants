using System;
using System.Collections.Generic;

namespace Test01.Data.Models.KB
{
    public partial class Template
    {
        public Template()
        {
            Category = new HashSet<Category>();
        }

        public int Id { get; set; }
        public int IdTemplatetype { get; set; }
        public string Name { get; set; }
        public string Htmltemplate { get; set; }
        public string Cuser { get; set; }
        public DateTime? Cdate { get; set; }
        public string Muser { get; set; }
        public DateTime? Mdate { get; set; }

        public virtual Templatetype IdTemplatetypeNavigation { get; set; }
        public virtual ICollection<Category> Category { get; set; }
    }
}
