using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace StockApp.Models
{
    public class DocumentTypeModel
    {
        public Guid DocTypeId { get; set; }

        [StringLength(50, ErrorMessage = "Campul nu poate fi mai mare de 50 de caractere")]
        [Display(Name = "Tip document")]
        public string? DocType { get; set; }
    }
}
