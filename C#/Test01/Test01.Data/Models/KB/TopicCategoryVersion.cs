using System;
using System.Collections.Generic;

namespace Test01.Data.Models.KB
{
    public partial class TopicCategoryVersion
    {
        public int Id { get; set; }
        public int TopicVersionId { get; set; }
        public int TopicId { get; set; }
        public int CategoryId { get; set; }
        public string Cuser { get; set; }
        public DateTime? Cdate { get; set; }
        public string Muser { get; set; }
        public DateTime? Mdate { get; set; }

        public virtual Category Category { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
