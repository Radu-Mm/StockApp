namespace StockApp.Models
{
    public class UsageModel
    {
        public Guid UsageId { get; set; }
        public Guid UsageTypeId { get; set; }
        public Guid DocdetId { get; set; }
        public Guid ProductId { get; set; }
        public double Quantity { get; set; }

        public Guid Docid { get; set; }

    }
}
