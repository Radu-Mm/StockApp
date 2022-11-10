using StockApp.Models;
using StockApp.Repository;

namespace StockApp.ViewModel
{
    public class UsageViewModel
    {

        public Guid UsageId { get; set; }
        public Guid UsageTypeId { get; set; }
        public Guid DocdetId { get; set; }
        public Guid ProductId { get; set; }
        public double Quantity { get; set; }
        public Guid DocID { get; set; }
        public string UsageType { get; set; }
        public string ProductName { get; set; }

        public Guid docid { get; set; }
        public string docNumber { get; set; }


        public UsageViewModel(UsageModel model, UsageTypeRepository usagetype, DocumentDetailsRepository docdet, ProductsRepository product, DocumentsRepository document)
        {
            this.UsageId = model.UsageId;
            this.UsageTypeId = model.UsageTypeId;
            var usagetypevar = usagetype.GetUsageTypeByID(UsageTypeId);
            this.UsageType = usagetypevar.UsageType1;
            this.DocID = model.Docid;
            this.DocdetId = model.DocdetId;
            var docdetidvar = docdet.GetDocumentDetailByID(DocdetId);
            this.docid = docdetidvar.DocId;
            var docIdVar = document.GetDocumentByID(docid);
            this.docNumber = docIdVar.DocNumber;
            
            this.ProductId = model.ProductId;
            var productName = product.GetProductByID(ProductId);
            this.ProductName = productName.ProductName;

            this.Quantity = model.Quantity;

        }

    }
}
