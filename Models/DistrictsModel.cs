namespace StockApp.Models
{
    public class DistrictsModel
    {
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; } = null!;
        public Guid CountryId { get; set; }
    }
}
