using System;
using System.Collections.Generic;

namespace Test01.Data.Models.KB
{
    public partial class Category
    {
        public Category()
        {
            InverseIdParentNavigation = new HashSet<Category>();
            TopicCategory = new HashSet<TopicCategory>();
            TopicCategoryVersion = new HashSet<TopicCategoryVersion>();
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
        public int? Position { get; set; }

        public virtual Category IdParentNavigation { get; set; }
        public virtual Template IdTemplateNavigation { get; set; }
        public virtual ICollection<Category> InverseIdParentNavigation { get; set; }
        public virtual ICollection<TopicCategory> TopicCategory { get; set; }
        public virtual ICollection<TopicCategoryVersion> TopicCategoryVersion { get; set; }
    }
}
