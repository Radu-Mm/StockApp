namespace StockApp.Models
{
    public class ProductsModel
    {
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? ProductCategory { get; set; }
        public bool ProductInUse { get; set; }
    }
}
