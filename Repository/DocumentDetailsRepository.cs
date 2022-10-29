using StockApp.Data;
using StockApp.Models.DBObjects;
using StockApp.Models;

namespace StockApp.Repository
{
    public class DocumentDetailsRepository
    {

        private readonly ApplicationDbContext _DBContext;

        public DocumentDetailsRepository()
        {
            _DBContext = new ApplicationDbContext();
        }

        public DocumentDetailsRepository(ApplicationDbContext dbContext)
        {
            _DBContext = dbContext;
        }

        private DocumentDetailsModel MapDBObjectToModel(DocumentDetail dbobject)
        {
            var model = new DocumentDetailsModel();
            if (dbobject != null)
            {
                model.DocDetId = dbobject.DocDetId;
                model.DocId = dbobject.DocId;
                model.ProductId = dbobject.ProductId;
                model.Unitprice = dbobject.Unitprice;
                model.Vat = dbobject.Vat;
                model.Quantity = dbobject.Quantity;
                model.QuantityRemaining = dbobject.QuantityRemaining;
            }
            return model;
        }

        private DocumentDetail MapModelToDBOject(DocumentDetailsModel model)
        {
            var dbobject = new DocumentDetail();
            if (model != null)
            {
                dbobject.DocDetId = model.DocDetId;
                dbobject.DocId = model.DocId;
                dbobject.ProductId = model.ProductId;
                dbobject.Unitprice = model.Unitprice;
                dbobject.Vat = model.Vat;
                dbobject.Quantity = model.Quantity;
                dbobject.QuantityRemaining = model.QuantityRemaining;
            }
            return dbobject;
        }

        public List<DocumentDetailsModel> GetAllDocumentDetails()
        {
            var list = new List<DocumentDetailsModel>();

            foreach (var dboject in _DBContext.DocumentDetails)
            {
                list.Add(MapDBObjectToModel(dboject));
            }
            return list;
        }

        public DocumentDetailsModel GetDocumentDetailByID(Guid ID)
        {
            return MapDBObjectToModel(_DBContext.DocumentDetails.FirstOrDefault(x => x.DocDetId == ID));
        }

        public void InsertDocumentDetails(DocumentDetailsModel model)
        {
            model.DocDetId = Guid.NewGuid();
            _DBContext.DocumentDetails.Add(MapModelToDBOject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateDocumentDetails(DocumentDetailsModel model)
        {
            var dbobject = _DBContext.DocumentDetails.FirstOrDefault(x => x.DocDetId == model.DocDetId);
            if (dbobject != null)
            {
                dbobject.DocDetId = model.DocDetId;
                dbobject.DocId = model.DocId;
                dbobject.ProductId = model.ProductId;
                dbobject.Unitprice = model.Unitprice;
                dbobject.Vat = model.Vat;
                dbobject.Quantity = model.Quantity;
                dbobject.QuantityRemaining = model.QuantityRemaining;

                _DBContext.SaveChanges();
            }
        }

        public void DeleteDocumentDetails(DocumentDetailsModel model)
        {
            var dboject = _DBContext.DocumentDetails.FirstOrDefault(x => x.DocDetId == model.DocDetId);
            if (dboject != null)
            {
                _DBContext.DocumentDetails.Remove(dboject);
                _DBContext.SaveChanges();
            }
        }

    }
}
