using System;
using System.Collections.Generic;

namespace StockApp.Models.DBObjects
{
    public partial class Document
    {
        public Document()
        {
            DocumentDetails = new HashSet<DocumentDetail>();
            Usages = new HashSet<Usage>();
        }

        public Guid DocId { get; set; }
        public Guid DocTypeId { get; set; }
        public string DocNumber { get; set; } = null!;
        public DateTime DocDate { get; set; }
        public Guid SellerId { get; set; }
        public decimal? DocTotalValue { get; set; }
        public decimal? DocTotalValueWithoutVat { get; set; }
        public decimal? DocTotalValueVat { get; set; }
        public bool IsValid { get; set; }
        public DateTime? WhenValidated { get; set; }
        public string? ValidatedBy { get; set; }

        public virtual DocumentType DocType { get; set; } = null!;
        public virtual Seller Seller { get; set; } = null!;
        public virtual ICollection<DocumentDetail> DocumentDetails { get; set; }
        public virtual ICollection<Usage> Usages { get; set; }
    }
}
