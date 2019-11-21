using System;
using System.Collections.Generic;

namespace Test01.Data.Models.KB
{
    public partial class Product
    {
        public Product()
        {
            Topic = new HashSet<Topic>();
            TopicVersion = new HashSet<TopicVersion>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cuser { get; set; }
        public DateTime? Cdate { get; set; }
        public string Muser { get; set; }
        public DateTime? Mdate { get; set; }

        public virtual ICollection<Topic> Topic { get; set; }
        public virtual ICollection<TopicVersion> TopicVersion { get; set; }
    }
}
