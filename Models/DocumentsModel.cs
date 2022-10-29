using StockApp.Models.DBObjects;
using System.ComponentModel.DataAnnotations;

namespace StockApp.Models
{
    public class DocumentsModel
    {

        public Guid DocId { get; set; }
        public Guid DocTypeId { get; set; }
        public string DocNumber { get; set; } = null!;

        [DisplayFormat(DataFormatString="0:MM/dd/yyyy")]
        [DataType(DataType.Date)]
        public DateTime DocDate { get; set; }
        public Guid SellerId { get; set; }
        public decimal? DocTotalValue { get; set; }
        public decimal? DocTotalValueWithoutVat { get; set; }
        public decimal? DocTotalValueVat { get; set; }
        public bool IsValid { get; set; }

        [DisplayFormat(DataFormatString = "0:MM/dd/yyyy")]
        [DataType(DataType.Date)]
        public DateTime? WhenValidated { get; set; }
        public string? ValidatedBy { get; set; }

        public virtual DocumentType DocType { get; set; } = null!;
        public virtual Seller Seller { get; set; } = null!;

    }
}
