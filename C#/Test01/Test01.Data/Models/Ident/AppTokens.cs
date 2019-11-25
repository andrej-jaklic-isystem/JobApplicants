using System;
using System.Collections.Generic;

namespace Test01.Data.Models.Ident
{
    public partial class AppTokens
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Purpose { get; set; }
        public string Provider { get; set; }
        public string Value { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime? UsageDate { get; set; }
        public bool IsUsed { get; set; }
        public DateTime? Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public string ModifiedBy { get; set; }

        public virtual AppUsers User { get; set; }
    }
}
