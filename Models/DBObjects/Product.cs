using System;
using System.Collections.Generic;

namespace StockApp.Models.DBObjects
{
    public partial class Product
    {
        public Product()
        {
            DocumentDetails = new HashSet<DocumentDetail>();
        }

        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public bool ProductInUse { get; set; }
        public Guid Productcategory { get; set; }

        public virtual Category? ProductcategoryNavigation { get; set; }
        public virtual ICollection<DocumentDetail> DocumentDetails { get; set; }
    }
}
