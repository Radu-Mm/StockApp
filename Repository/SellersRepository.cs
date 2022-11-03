using StockApp.Data;
using StockApp.Models.DBObjects;
using StockApp.Models;

namespace StockApp.Repository
{
    public class SellersRepository
    {

        private readonly ApplicationDbContext _DBContext;

        public SellersRepository()
        {
            _DBContext = new ApplicationDbContext();
        }

        public SellersRepository(ApplicationDbContext dbContext)
        {
            _DBContext = dbContext;
        }

        private SellersModel MapDBObjectToModel(Seller dbobject)
        {
            var model = new SellersModel();
            if (dbobject != null)
            {
                model.SellerId = dbobject.SellerId;
                model.SellerName = dbobject.SellerName;
                model.SellerUic = dbobject.SellerUic;
                model.SellerCountry = dbobject.SellerCountry;
                model.SellerDistrict = dbobject.SellerDistrict;
                model.SellerAddress = dbobject.SellerAddress;
                model.SellerPhone = dbobject.SellerPhone;
                model.BlackListed = dbobject.BlackListed;
                model.BlackListMotive = dbobject.BlackListMotive;
                model.BlackListTime = dbobject.BlackListTime;
                model.BlackListWho = dbobject.BlackListWho;
            }
            return model;
        }

        private Seller MapModelToDBOject(SellersModel model)
        {
            var dbobject = new Seller();
            if (model != null)
            {
                dbobject.SellerId = model.SellerId;
                dbobject.SellerName = model.SellerName;
                dbobject.SellerUic = model.SellerUic;
                dbobject.SellerCountry = model.SellerCountry;
                dbobject.SellerDistrict = model.SellerDistrict;
                dbobject.SellerAddress = model.SellerAddress;
                dbobject.SellerPhone = model.SellerPhone;
                dbobject.BlackListed = model.BlackListed;
                dbobject.BlackListMotive = model.BlackListMotive;
                dbobject.BlackListTime = model.BlackListTime;
                dbobject.BlackListWho = model.BlackListWho;
            }
            return dbobject;
        }

        public List<SellersModel> GetAllSellers()
        {
            var list = new List<SellersModel>();

            foreach (var dboject in _DBContext.Sellers)
            {
                list.Add(MapDBObjectToModel(dboject));
            }
            return list;
        }

        public SellersModel GetSellerByID(Guid ID)
        {
            return MapDBObjectToModel(_DBContext.Sellers.FirstOrDefault(x => x.SellerId == ID));
        }

        public void InsertSeller(SellersModel model)
        {
            model.SellerId = Guid.NewGuid();
            _DBContext.Sellers.Add(MapModelToDBOject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateSeller(SellersModel model)
        {
            var dbobject = _DBContext.Sellers.FirstOrDefault(x => x.SellerId == model.SellerId);
            if (dbobject != null)
            {
                dbobject.SellerId = model.SellerId;
                dbobject.SellerName = model.SellerName;
                dbobject.SellerUic = model.SellerUic;
                dbobject.SellerCountry = model.SellerCountry;
                dbobject.SellerDistrict = model.SellerDistrict;
                dbobject.SellerAddress = model.SellerAddress;
                dbobject.SellerPhone = model.SellerPhone;
                dbobject.BlackListed = model.BlackListed;
                dbobject.BlackListMotive = model.BlackListMotive;
                dbobject.BlackListTime = model.BlackListTime;
                dbobject.BlackListWho = model.BlackListWho;

                _DBContext.SaveChanges();
            }
        }

        public void DeleteSeller(Guid ID)
        {
            var dboject = _DBContext.Sellers.FirstOrDefault(x => x.SellerId == ID);
            if (dboject != null)
            {
                _DBContext.Sellers.Remove(dboject);
                _DBContext.SaveChanges();
            }
        }

    }
}
