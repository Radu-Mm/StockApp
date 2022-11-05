namespace StockApp.Models
{
    public class ProductsModel
    {
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }

        public bool ProductInUse { get; set; }

        public Guid ProductCategory { get; set; }
    }
}
