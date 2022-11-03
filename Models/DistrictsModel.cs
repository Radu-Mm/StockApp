using System.ComponentModel.DataAnnotations;

namespace StockApp.Models
{
    public class DistrictsModel
    {
        public Guid DistrictId { get; set; }
        [Display(Name = "Nume Judet/District")]
        public string DistrictName { get; set; } = null!;

        [Display(Name ="Country Name")]
        public Guid CountryId { get; set; }

    //   public string CountryName { get; set; }
    }
}
