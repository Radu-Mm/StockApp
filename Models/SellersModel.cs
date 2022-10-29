namespace StockApp.Models
{
    public class SellersModel
    {
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
    }
}
