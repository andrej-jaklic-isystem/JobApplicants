using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test01.Models
{
    public partial class TopicEvent
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public int EventtypeId { get; set; }
        public DateTime Eventdate { get; set; }
        public int? AppUserId { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Emailto { get; set; }
        public bool? IsVisible { get; set; }
        public string Cuser { get; set; }
        public DateTime Cdate { get; set; }
        public string Muser { get; set; }
        public DateTime? Mdate { get; set; }

        public int? AssigneeId { get; set; }

        public int? StatusId { get; set; }
        
        public virtual Topic Topic { get; set; }

    }
}
