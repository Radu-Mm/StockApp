using System;
using System.Collections.Generic;

namespace StockApp.Models.DBObjects
{
    public partial class Usage
    {
        public Guid UsageId { get; set; }
        public Guid UsageTypeId { get; set; }
        public Guid DocdetId { get; set; }
        public Guid ProductId { get; set; }
        public double Quantity { get; set; }

        public virtual DocumentDetail Docdet { get; set; }
        public virtual Product Product { get; set; }
        public virtual UsageType UsageType { get; set; }
    }
}
