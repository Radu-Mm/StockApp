using System.ComponentModel.DataAnnotations;

namespace StockApp.Models
{
    public class DistrictsModel
    {
        public Guid DistrictId { get; set; }
        [StringLength(100, ErrorMessage = "Campul nu poate fi mai mare de 100 de caractere")]
        [Display(Name = "Nume Judet/District")]
        public string DistrictName { get; set; } = null!;
               
        [Display(Name ="Tara")]
        public Guid CountryId { get; set; }

    //   public string CountryName { get; set; }
    }
}
