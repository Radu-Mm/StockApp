using StockApp.Data;
using StockApp.Models.DBObjects;
using StockApp.Models;

namespace StockApp.Repository
{
    public class DistrictsRepository
    {

        private readonly ApplicationDbContext _DBContext;

        public DistrictsRepository()
        {
            _DBContext = new ApplicationDbContext();
        }

        public DistrictsRepository(ApplicationDbContext dbContext)
        {
            _DBContext = dbContext;
        }

        private DistrictsModel MapDBObjectToModel(District dboject)
        {
            var model = new DistrictsModel();
            if (dboject != null)
            {
                model.DistrictName = dboject.DistrictName;
                model.DistrictId = dboject.DistrictId;
                model.CountryId = dboject.CountryId;
                 
            }
            return model;
        }

        private District MapModelToDBOject(DistrictsModel model)
        {
            var dbobject = new District();
            if (model != null)
            {
                dbobject.DistrictName = model.DistrictName;
                dbobject.DistrictId = model.DistrictId;
                dbobject.CountryId = model.CountryId;
            }
            return dbobject;
        }

        public List<DistrictsModel> GetAllDistricts()
        {
            var list = new List<DistrictsModel>();

            foreach (var dboject in _DBContext.Districts)
            {
                list.Add(MapDBObjectToModel(dboject));
            }
            return list;
        }

        public DistrictsModel GetDistrictByID(Guid ID)
        {
            return MapDBObjectToModel(_DBContext.Districts.FirstOrDefault(x => x.DistrictId == ID));
        }

        public void InsertDistrict(DistrictsModel model)
        {
            model.DistrictId = Guid.NewGuid();
            _DBContext.Districts.Add(MapModelToDBOject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateDistrict(DistrictsModel model)
        {
            var dbobject = _DBContext.Districts.FirstOrDefault(x => x.DistrictId == model.DistrictId);
            if (dbobject != null)
            {
                dbobject.DistrictId = model.DistrictId;
                dbobject.DistrictName = model.DistrictName;

                dbobject.CountryId = model.CountryId;
                _DBContext.SaveChanges();
            }
        }

        public void DeleteDistrict(DistrictsModel model)
        {
            var dboject = _DBContext.Districts.FirstOrDefault(x => x.DistrictId == model.DistrictId);
            if (dboject != null)
            {
                _DBContext.Districts.Remove(dboject);
                _DBContext.SaveChanges();
            }
        }

    }
}
