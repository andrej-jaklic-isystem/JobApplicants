
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace Test01.Models
{
    public partial class Topic
    {
        public Topic()
        {
            TopicCategory = new HashSet<TopicCategory>();
            TopicEvent = new HashSet<TopicEvent>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string AliasUrl { get; set; }
        public int StatusId { get; set; }
        public int RobotId { get; set; }
        public bool IsVisible { get; set; }
        public int CreatorId { get; set; }
        public int? RequestorId { get; set; }
        public int? AssigneeId { get; set; }
        public int? EditorId { get; set; }

        [Display(Name = "Publish starts")]
        public DateTime? PublishStart { get; set; }

        [Display(Name = "Publish ends")]
        public DateTime? PublishStop { get; set; }
        public int? ProductId { get; set; }
        public int? Featured { get; set; }
        public string ValidProductStart { get; set; }
        public string ValidProductStop { get; set; }
        public string Content { get; set; }
        public string MetaAuthor { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public DateTime? LastResolved { get; set; }
        public DateTime? Deadline { get; set; }
        public string Cuser { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? Cdate { get; set; }
        public string Muser { get; set; }
        public DateTime? Mdate { get; set; }
        public bool? IsDeleted { get; set; }
        public decimal? AvgRating { get; set; }
        public int? NumViews { get; set; }


        public virtual ICollection<TopicCategory> TopicCategory { get; set; }

        public virtual ICollection<TopicEvent> TopicEvent { get; set; }

        [Display(Name = "Feedbacks")]
        public virtual ICollection<TopicFeedback> TopicFeedback { get; set; }
    }
}
