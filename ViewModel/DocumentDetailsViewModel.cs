using StockApp.Models;
using StockApp.Repository;

namespace StockApp.ViewModel
{
    public class DocumentDetailsViewModel
    {
        public Guid DocDetId { get; set; }
        public Guid DocId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Unitprice { get; set; }
        public double Vat { get; set; }
        public double Quantity { get; set; }
        public decimal  QuantityRemaining { get; set; }

        public string Document { get; set; }
        public string Product { get; set; }

        public DocumentDetailsViewModel(DocumentDetailsModel model, DocumentsRepository documents, ProductsRepository products)
        { 
            this.DocDetId = model.DocDetId;
            this.DocId = model.DocId;
            var document = documents.GetDocumentByID(DocId);
            Document = document.DocNumber;
            this.ProductId = model.ProductId;
            var product = products.GetProductByID(ProductId);
            this.Product = product.ProductName;
            this.Unitprice = model.Unitprice;
            this.Vat = model.Vat;
            this.Quantity = model.Quantity;
           
            
        }
             

        }
}
