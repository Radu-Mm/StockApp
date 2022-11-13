using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace StockApp.Models
{
    public class SellersModel
    {
        public Guid SellerId { get; set; }
        [StringLength(100, ErrorMessage = "Campul nu poate fi mai mare de 100 de caractere")]
        [Display(Name = "Furnizor")]
        public string? SellerName { get; set; }

        [StringLength(20, ErrorMessage = "Campul nu poate fi mai mare de 20 de caractere")]
        [Display(Name = "Cod Identificare")]
        public string? SellerUic { get; set; }
        public Guid SellerCountry { get; set; }
        public Guid SellerDistrict { get; set; }

        [StringLength(500, ErrorMessage = "Campul nu poate fi mai mare de 500 de caractere")]
        [Display(Name = "Adresa Furnizor")]
        public string? SellerAddress { get; set; }

        [StringLength(13, ErrorMessage = "Campul nu poate fi mai mare de 13 de caractere")]
        [Display(Name = "Nr. Telefon")]
        public string? SellerPhone { get; set; }
        public bool BlackListed { get; set; }
 
        [Display(Name = "Motiv incheiere tranzactii")]
        public string? BlackListMotive { get; set; }
        public DateTime? BlackListTime { get; set; }
        public string? BlackListWho { get; set; }
    }
}
