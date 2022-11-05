using StockApp.Data;
using StockApp.Models.DBObjects;
using StockApp.Models;
using StockApp.ViewModel;

namespace StockApp.Repository
{
    public class DocumentsRepository
    {

        private readonly ApplicationDbContext _DBContext;

        public DocumentsRepository()
        {
            _DBContext = new ApplicationDbContext();
        }

        public DocumentsRepository(ApplicationDbContext dbContext)
        {
            _DBContext = dbContext;
        }

        private DocumentsModel MapDBObjectToModel(Document dbobject)
        {
            var model = new DocumentsModel();
            if (dbobject != null)
            {
                model.DocId = dbobject.DocId;
                model.DocTypeId = dbobject.DocTypeId;
                model.DocNumber = dbobject.DocNumber;
                model.DocDate = dbobject.DocDate;
                model.SellerId = dbobject.SellerId;
                model.DocTotalValue = dbobject.DocTotalValue;
                model.DocTotalValueWithoutVat = dbobject.DocTotalValueWithoutVat;
                model.DocTotalValueVat = dbobject.DocTotalValueVat;
                model.IsValid = dbobject.IsValid;
                model.WhenValidated = dbobject.WhenValidated;
                model.ValidatedBy = dbobject.ValidatedBy; 
            }
            return model;
        }

        private Document MapModelToDBOject(DocumentsModel model)
        {
            var dbobject = new Document();
            if (model != null)
            {
                dbobject.DocId = model.DocId;
                dbobject.DocTypeId = model.DocTypeId;
                dbobject.DocNumber = model.DocNumber;
                dbobject.DocDate = model.DocDate;
                dbobject.SellerId = model.SellerId;
                dbobject.DocTotalValue = model.DocTotalValue;
                dbobject.DocTotalValueWithoutVat = model.DocTotalValueWithoutVat;
                dbobject.DocTotalValueVat = model.DocTotalValueVat;
                dbobject.IsValid = model.IsValid;
                dbobject.WhenValidated = model.WhenValidated;
                dbobject.ValidatedBy = model.ValidatedBy;
            }
            return dbobject;
        }

        public List<DocumentsModel> GetAllDocuments()
        {
            var list = new List<DocumentsModel>();

            foreach (var dboject in _DBContext.Documents)
            {
                list.Add(MapDBObjectToModel(dboject));
            }
            return list;
        }


        public DocumentsModel GetDocumentByID(Guid ID)
        {
            return MapDBObjectToModel(_DBContext.Documents.FirstOrDefault(x => x.DocId == ID));
        }

        public void InsertDocument(DocumentsModel model)
        {
            model.DocId = Guid.NewGuid();
            _DBContext.Documents.Add(MapModelToDBOject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateDocument(DocumentsModel model)
        {
            var dbobject = _DBContext.Documents.FirstOrDefault(x => x.DocId == model.DocId);
            if (dbobject != null)
            {
                dbobject.DocId = model.DocId;
                dbobject.DocTypeId = model.DocTypeId;
                dbobject.DocNumber = model.DocNumber;
                dbobject.DocDate = model.DocDate;
                dbobject.SellerId = model.SellerId;
                dbobject.DocTotalValue = model.DocTotalValue;
                dbobject.DocTotalValueWithoutVat = model.DocTotalValueWithoutVat;
                dbobject.DocTotalValueVat = model.DocTotalValueVat;
                dbobject.IsValid = model.IsValid;
                dbobject.WhenValidated = model.WhenValidated;
                dbobject.ValidatedBy = model.ValidatedBy;

                _DBContext.SaveChanges();
            }
        }

        public void DeleteDocument(Guid ID)
        {
            var dboject = _DBContext.Documents.FirstOrDefault(x => x.DocId == ID);
            if (dboject != null)
            {
                _DBContext.Documents.Remove(dboject);
                _DBContext.SaveChanges();
            }
        }

    }
}
