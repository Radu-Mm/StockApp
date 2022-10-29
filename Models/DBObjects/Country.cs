using System;
using System.Collections.Generic;

namespace StockApp.Models.DBObjects
{
    public partial class Country
    {
        public Country()
        {
            Districts = new HashSet<District>();
            Sellers = new HashSet<Seller>();
        }

        public Guid CountryId { get; set; }
        public string CountryName { get; set; } = null!;

        public virtual ICollection<District> Districts { get; set; }
        public virtual ICollection<Seller> Sellers { get; set; }
    }
}
