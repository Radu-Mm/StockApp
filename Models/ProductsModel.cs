using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace StockApp.Models
{
    public class ProductsModel
    {
        public Guid ProductId { get; set; }

        [StringLength(200, ErrorMessage = "Campul nu poate fi mai mare de 200 de caractere")]
        [Display(Name = "Produs")]
        public string? ProductName { get; set; }

        public bool ProductInUse { get; set; }

        public Guid ProductCategory { get; set; }
    }
}
