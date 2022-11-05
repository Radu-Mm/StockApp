using StockApp.Models.DBObjects;

namespace StockApp.Models
{
    public class DocumentDetailsModel
    {
        public Guid DocDetId { get; set; }
        public Guid DocId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Unitprice { get; set; }
        public double Vat { get; set; }
        
        public double Quantity { get; set; }
        public double QuantityRemaining { get; set; }

        public virtual Document Doc { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;

    }
}
