using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace StockApp.Models
{
    public class CategoriesModel
    {
        public Guid CategoryId { get; set; }

        [StringLength(100, ErrorMessage = "Campul nu poate fi mai mare de 100 de caractere")]
        [Display(Name = "Categorie")]
        public string? CategoyName { get; set; }

        [StringLength(1000, ErrorMessage = "Campul nu poate fi mai mare de 1000 de caractere")]
        [Display(Name = "Descriere")]
        public string? CategoryDescription { get; set; }
    }
}
