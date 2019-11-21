using System;
using System.Collections.Generic;

namespace Test01.Data.Models.KB
{
    public partial class FeedbackType
    {
        public FeedbackType()
        {
            TopicFeedback = new HashSet<TopicFeedback>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool IsPositive { get; set; }
        public string Cuser { get; set; }
        public DateTime? Cdate { get; set; }
        public string Muser { get; set; }
        public DateTime? Mdate { get; set; }

        public virtual ICollection<TopicFeedback> TopicFeedback { get; set; }
    }
}
