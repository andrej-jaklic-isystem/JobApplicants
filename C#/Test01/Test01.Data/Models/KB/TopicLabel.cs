using System;
using System.Collections.Generic;

namespace Test01.Data.Models.KB
{
    public partial class TopicLabel
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public int LabelId { get; set; }
        public string Cuser { get; set; }
        public DateTime? Cdate { get; set; }
        public string Muser { get; set; }
        public DateTime? Mdate { get; set; }

        public virtual Label Label { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
