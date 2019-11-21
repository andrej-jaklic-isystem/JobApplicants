using System;
using System.Collections.Generic;

namespace Test01.Data.Models.KB
{
    public partial class Label
    {
        public Label()
        {
            TopicLabel = new HashSet<TopicLabel>();
        }

        public int Id { get; set; }
        public string Label1 { get; set; }
        public string Description { get; set; }
        public string Class { get; set; }
        public string Attributes { get; set; }
        public string Cuser { get; set; }
        public DateTime? Cdate { get; set; }
        public string Muser { get; set; }
        public DateTime? Mdate { get; set; }

        public virtual ICollection<TopicLabel> TopicLabel { get; set; }
    }
}
