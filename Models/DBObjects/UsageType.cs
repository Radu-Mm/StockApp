using System;
using System.Collections.Generic;

namespace StockApp.Models.DBObjects
{
    public partial class UsageType
    {
        public UsageType()
        {
            Usages = new HashSet<Usage>();
        }

        public Guid UsageTypeId { get; set; }
        public string? UsageType1 { get; set; }

        public virtual ICollection<Usage> Usages { get; set; }
    }
}
