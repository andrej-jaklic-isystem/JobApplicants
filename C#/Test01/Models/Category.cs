using System;
using System.Collections.Generic;

namespace Test01.Models
{
    public partial class Category
    {
        public Category()
        {
            InverseIdParentNavigation = new HashSet<Category>();
            TopicCategory = new HashSet<TopicCategory>();
        }

        public int Id { get; set; }
        public int? IdParent { get; set; }
        public int? IdTemplate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Imageurl { get; set; }
        public string Cuser { get; set; }
        public DateTime? Cdate { get; set; }
        public string Muser { get; set; }
        public DateTime? Mdate { get; set; }

        public virtual Category IdParentNavigation { get; set; }
        public virtual ICollection<Category> InverseIdParentNavigation { get; set; }
        public virtual ICollection<TopicCategory> TopicCategory { get; set; }
     
    }
}
