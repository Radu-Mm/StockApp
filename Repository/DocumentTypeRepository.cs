using StockApp.Data;
using StockApp.Models.DBObjects;
using StockApp.Models;

namespace StockApp.Repository
{
    public class DocumentTypeRepository
    {

        private readonly ApplicationDbContext _DBContext;

        public DocumentTypeRepository()
        {
            _DBContext = new ApplicationDbContext();
        }

        public DocumentTypeRepository(ApplicationDbContext dbContext)
        {
            _DBContext = dbContext;
        }

        private DocumentTypeModel MapDBObjectToModel(DocumentType dbobject)
        {
            var model = new DocumentTypeModel();
            if (dbobject != null)
            {
                model.DocTypeId = dbobject.DocTypeId;
                model.DocType = dbobject.DocType;
            }
            return model;
        }

        private DocumentType MapModelToDBOject(DocumentTypeModel model)
        {
            var dbobject = new DocumentType();
            if (model != null)
            {
                dbobject.DocTypeId = model.DocTypeId;
                dbobject.DocType = model.DocType;
            }
            return dbobject;
        }

        public List<DocumentTypeModel> GetAllDocumentTypes()
        {
            var list = new List<DocumentTypeModel>();

            foreach (var dboject in _DBContext.DocumentTypes)
            {
                list.Add(MapDBObjectToModel(dboject));
            }
            return list;
        }

        public DocumentTypeModel GetDocumentTypeByID(Guid ID)
        {
            return MapDBObjectToModel(_DBContext.DocumentTypes.FirstOrDefault(x => x.DocTypeId == ID));
        }

        public void InsertDocumentType(DocumentTypeModel model)
        {
            model.DocTypeId = Guid.NewGuid();
            _DBContext.DocumentTypes.Add(MapModelToDBOject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateDocumentType(DocumentTypeModel model)
        {
            var dbobject = _DBContext.DocumentTypes.FirstOrDefault(x => x.DocTypeId == model.DocTypeId);
            if (dbobject != null)
            {
                dbobject.DocTypeId = model.DocTypeId;
                dbobject.DocType = model.DocType;

                _DBContext.SaveChanges();
            }
        }

        public void DeleteDocumentType(Guid ID)
        {
            var dboject = _DBContext.DocumentTypes.FirstOrDefault(x => x.DocTypeId == ID);
            if (dboject != null)
            {

                _DBContext.DocumentTypes.Remove(dboject);
                _DBContext.SaveChanges();
            }
        }

    }
}
