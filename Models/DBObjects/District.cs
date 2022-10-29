using System;
using System.Collections.Generic;

namespace StockApp.Models.DBObjects
{
    public partial class District
    {
        public District()
        {
            Sellers = new HashSet<Seller>();
        }

        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; } = null!;
        public Guid CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<Seller> Sellers { get; set; }
    }
}
