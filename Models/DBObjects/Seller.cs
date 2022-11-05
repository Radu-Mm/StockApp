using System;
using System.Collections.Generic;

namespace StockApp.Models.DBObjects
{
    public partial class Seller
    {
        public Seller()
        {
            Documents = new HashSet<Document>();
        }

        public Guid SellerId { get; set; }
        public string? SellerName { get; set; }
        public string? SellerUic { get; set; }
        public Guid SellerCountry { get; set; }
        public Guid SellerDistrict { get; set; }
        public string? SellerAddress { get; set; }
        public string? SellerPhone { get; set; }
        public bool BlackListed { get; set; }
        public string? BlackListMotive { get; set; }
        public DateTime? BlackListTime { get; set; }
        public string? BlackListWho { get; set; }

        public virtual Country SellerCountryNavigation { get; set; } = null!;
        public virtual District SellerDistrictNavigation { get; set; } = null!;
        public virtual ICollection<Document> Documents { get; set; }
    }
}
