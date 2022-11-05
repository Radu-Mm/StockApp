using StockApp.Data;
using StockApp.Models.DBObjects;
using StockApp.Models;

namespace StockApp.Repository
{
    public class UsageTypeRepository
    {
        private readonly ApplicationDbContext _DBContext;

        public UsageTypeRepository()
        {
            _DBContext = new ApplicationDbContext();
        }

        public UsageTypeRepository(ApplicationDbContext dbContext)
        {
            _DBContext = dbContext;
        }

        private UsageTypeModel MapDBObjectToModel(UsageType dboject)
        {
            var model = new UsageTypeModel();
            if (dboject != null)
            {
                model.UsageTypeId = dboject.UsageTypeId;
                model.UsageType1 = dboject.UsageType1;
            }
            return model;
        }

        private UsageType MapModelToDBOject(UsageTypeModel model)
        {
            var dbobject = new UsageType();
            if (model != null)
            {
                dbobject.UsageTypeId = model.UsageTypeId;
                dbobject.UsageType1 = model.UsageType1;
            }
            return dbobject;
        }

        public List<UsageTypeModel> GetAllUsageTypes()
        {
            var list = new List<UsageTypeModel>();

            foreach (var dboject in _DBContext.UsageTypes)
            {
                list.Add(MapDBObjectToModel(dboject));
            }
            return list;
        }

        public UsageTypeModel GetUsageTypeByID(Guid ID)
        {
            return MapDBObjectToModel(_DBContext.UsageTypes.FirstOrDefault(x => x.UsageTypeId == ID));
        }

        public void InsertUsageType(UsageTypeModel model)
        {
            model.UsageTypeId = Guid.NewGuid();
            _DBContext.UsageTypes.Add(MapModelToDBOject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateUsageTypes(UsageTypeModel model)
        {
            var dbobject = _DBContext.UsageTypes.FirstOrDefault(x => x.UsageTypeId == model.UsageTypeId);
            if (dbobject != null)
            {
                dbobject.UsageTypeId = model.UsageTypeId;
                dbobject.UsageType1 = model.UsageType1;
                _DBContext.SaveChanges();
            }
        }

        public void DeleteUsageTypes(Guid ID)
        {
            var dboject = _DBContext.UsageTypes.FirstOrDefault(x => x.UsageTypeId == ID);
            if (dboject != null)
            {
                _DBContext.UsageTypes.Remove(dboject);
                _DBContext.SaveChanges();
            }
        }

    }
}
