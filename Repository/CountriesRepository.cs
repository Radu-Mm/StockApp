using StockApp.Data;
using StockApp.Models.DBObjects;
using StockApp.Models;

namespace StockApp.Repository
{
    public class CountriesRepository
    {

        private readonly ApplicationDbContext _DBContext;

        public CountriesRepository()
        {
            _DBContext = new ApplicationDbContext();
        }

        public CountriesRepository(ApplicationDbContext dbContext)
        {
            _DBContext = dbContext;
        }

        private CountriesModel MapDBObjectToModel(Country dboject)
        {
            var model = new CountriesModel();
            if (dboject != null)
            {
                model.CountryId = dboject.CountryId;
                model.CountryName = dboject.CountryName; 
            }
            return model;
        }

        private Country MapModelToDBOject(CountriesModel model)
        {
            var dbobject = new Country();
            if (model != null)
            {
                dbobject.CountryId = model.CountryId;
                dbobject.CountryName = model.CountryName;
            }
            return dbobject;
        }

        public List<CountriesModel> GetAllCountries()
        {
            var list = new List<CountriesModel>();

            foreach (var dboject in _DBContext.Countries)
            {
                list.Add(MapDBObjectToModel(dboject));
            }
            return list;
        }

        public CountriesModel GetCountryByID(Guid ID)
        {
            return MapDBObjectToModel(_DBContext.Countries.FirstOrDefault(x => x.CountryId == ID));
        }

        public void InsertCountry(CountriesModel model)
        {
            model.CountryId = Guid.NewGuid();
            _DBContext.Countries.Add(MapModelToDBOject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateCountry(CountriesModel model)
        {
            var dbobject = _DBContext.Countries.FirstOrDefault(x => x.CountryId == model.CountryId);
            if (dbobject != null)
            {
                dbobject.CountryId = model.CountryId;
                dbobject.CountryName = model.CountryName;
                _DBContext.SaveChanges();
            }
        }

        public void DeleteCountry(CountriesModel model)
        {
            var dboject = _DBContext.Countries.FirstOrDefault(x => x.CountryId == model.CountryId);
            if (dboject != null)
            {
                //var districts = _DBContext.Districts.Select(x => x.CountryId == dboject.CountryId);
                //foreach(var district in dboject.Districts)
                //{
                //    //_DBContext.DistrictsRepository
                //}
                _DBContext.Countries.Remove(dboject);
                _DBContext.SaveChanges();
            }
        }

    }
}
