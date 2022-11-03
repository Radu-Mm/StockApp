using System.ComponentModel.DataAnnotations;

namespace StockApp.Models
{
    public class CountriesModel
    {
        public Guid CountryId { get; set; }

        [StringLength(100,ErrorMessage = "Campul nu poate fi mai mare de 100 de caractere")]
        [Display(Name ="Tara")]
        public string CountryName { get; set; } = null!;
    }
}
