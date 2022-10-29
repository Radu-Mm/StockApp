using System;
using System.Collections.Generic;

namespace StockApp.Models.DBObjects
{
    public partial class Category
    {
        public Guid CategoryId { get; set; }
        public string? CategoyName { get; set; }
        public string? CategoryDescription { get; set; }
    }
}
