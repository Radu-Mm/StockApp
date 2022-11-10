using StockApp.Data;
using StockApp.Models.DBObjects;
using StockApp.Models;
using StockApp.ViewModel;

namespace StockApp.Repository
{
    public class UsageRepository
    {

        private readonly ApplicationDbContext _DBContext;

        public UsageRepository()
        {
            _DBContext = new ApplicationDbContext();
        }

        public UsageRepository(ApplicationDbContext dbContext)
        {
            _DBContext = dbContext;
        }

        private UsageModel MapDBObjectToModel(Usage dboject)
        {
            var model = new UsageModel();
            if (dboject != null)
            {
                model.UsageId = dboject.UsageId;
                model.UsageTypeId = dboject.UsageTypeId;
                model.DocdetId = dboject.DocdetId;
                model.ProductId = dboject.ProductId;
                model.Quantity = dboject.Quantity;
                model.Docid = dboject.Docid;
            }
            return model;
        }

        private Usage MapModelToDBOject(UsageModel model)
        {
            var dbobject = new Usage();
            if (model != null)
            {
                dbobject.UsageId = model.UsageId;
                dbobject.UsageTypeId = model.UsageTypeId;
                dbobject.DocdetId = model.DocdetId;
                dbobject.ProductId = model.ProductId;
                dbobject.Quantity = model.Quantity;
                dbobject.Docid = model.Docid;
            }
            return dbobject;
        }

        public List<UsageModel> GetAllUsage()
        {
            var list = new List<UsageModel>();

            foreach (var dboject in _DBContext.Usages)
            {
                list.Add(MapDBObjectToModel(dboject));
            }
            return list;
        }

        public UsageModel GetUsageByID(Guid ID)
        {
            return MapDBObjectToModel(_DBContext.Usages.FirstOrDefault(x => x.UsageId == ID));
        }

        public void InsertUsage(UsageModel model)
        {
            model.UsageId = Guid.NewGuid();
            _DBContext.Usages.Add(MapModelToDBOject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateUsage(UsageModel model)
        {
            var dbobject = _DBContext.Usages.FirstOrDefault(x => x.UsageId == model.UsageId);
            if (dbobject != null)
            {
                dbobject.UsageId = model.UsageId;
                dbobject.UsageTypeId = model.UsageTypeId;
                dbobject.DocdetId = model.DocdetId;
                dbobject.ProductId = model.ProductId;
                dbobject.Quantity = model.Quantity;
                dbobject.Docid = model.Docid;
                _DBContext.SaveChanges();
            }
        }

        public void DeleteUsage(Guid ID)
        {
            var dboject = _DBContext.Usages.FirstOrDefault(x => x.UsageId == ID);
            if (dboject != null)
            {
                _DBContext.Usages.Remove(dboject);
                _DBContext.SaveChanges();
            }
        }

    }
}
