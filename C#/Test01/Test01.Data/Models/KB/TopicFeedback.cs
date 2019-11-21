using System;
using System.Collections.Generic;

namespace Test01.Data.Models.KB
{
    public partial class TopicFeedback
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public int FeedbackTypeId { get; set; }
        public DateTime FeedbackDate { get; set; }
        public string FeedbackComment { get; set; }
        public string Cuser { get; set; }
        public DateTime Cdate { get; set; }
        public string Muser { get; set; }
        public DateTime? Mdate { get; set; }

        public virtual FeedbackType FeedbackType { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
