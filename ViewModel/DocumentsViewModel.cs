using StockApp.Models;
using StockApp.Models.DBObjects;
using StockApp.Repository;

namespace StockApp.ViewModel
{
    public class DocumentsViewModel
    {
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


        public DateOnly DocdateWTime { get; set; }
        public string DocumentType { get; set; } = null!;
        public string SellerName { get; set; } = null!;
        public DocumentsViewModel(DocumentsModel model, SellersRepository seller, DocumentTypeRepository doctype)
        {
            this.DocId=model.DocId;
            this.DocTypeId=model.DocTypeId;
            var getdoctype = doctype.GetDocumentTypeByID(DocTypeId);
            this.DocumentType = getdoctype.DocType;
            this.DocNumber = model.DocNumber;
            this.DocDate = model.DocDate;
 


            this.SellerId = model.SellerId;
            var getseller = seller.GetSellerByID(SellerId);
            this.SellerName = getseller.SellerName;
            this.DocTotalValue = model.DocTotalValue;
            this.DocTotalValueWithoutVat = model.DocTotalValueWithoutVat;
            this.DocTotalValueVat = model.DocTotalValueVat;
            this.IsValid = model.IsValid;
            this.WhenValidated = model.WhenValidated;
            this.ValidatedBy = model.ValidatedBy;
        } 
    }
}
