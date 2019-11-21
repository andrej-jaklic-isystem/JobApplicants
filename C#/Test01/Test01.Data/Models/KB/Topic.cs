using System;
using System.Collections.Generic;

namespace Test01.Data.Models.KB
{
    public partial class Topic
    {
        public Topic()
        {
            TopicCategory = new HashSet<TopicCategory>();
            TopicCategoryVersion = new HashSet<TopicCategoryVersion>();
            TopicEvent = new HashSet<TopicEvent>();
            TopicFeedback = new HashSet<TopicFeedback>();
            TopicLabel = new HashSet<TopicLabel>();
            TopicVersion = new HashSet<TopicVersion>();
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
        public DateTime? PublishStart { get; set; }
        public DateTime? PublishStop { get; set; }
        public int? ProductId { get; set; }
        public string ValidProductStart { get; set; }
        public string ValidProductStop { get; set; }
        public string Content { get; set; }
        public string MetaAuthor { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public DateTime? LastResolved { get; set; }
        public DateTime? Deadline { get; set; }
        public string Cuser { get; set; }
        public DateTime? Cdate { get; set; }
        public string Muser { get; set; }
        public DateTime? Mdate { get; set; }
        public bool? IsDeleted { get; set; }
        public decimal? AvgRating { get; set; }
        public int? NumViews { get; set; }
        public string Contentastext { get; set; }
        public int? Featured { get; set; }

        public virtual Product Product { get; set; }
        public virtual Robot Robot { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<TopicCategory> TopicCategory { get; set; }
        public virtual ICollection<TopicCategoryVersion> TopicCategoryVersion { get; set; }
        public virtual ICollection<TopicEvent> TopicEvent { get; set; }
        public virtual ICollection<TopicFeedback> TopicFeedback { get; set; }
        public virtual ICollection<TopicLabel> TopicLabel { get; set; }
        public virtual ICollection<TopicVersion> TopicVersion { get; set; }
    }
}
