using StockApp.Data;
using StockApp.Models.DBObjects;
using StockApp.Models;

namespace StockApp.Repository
{
    public class ProductsRepository
    {

        private readonly ApplicationDbContext _DBContext;

        public ProductsRepository()
        {
            _DBContext = new ApplicationDbContext();
        }

        public ProductsRepository(ApplicationDbContext dbContext)
        {
            _DBContext = dbContext;
        }

        private ProductsModel MapDBObjectToModel(Product dbobject)
        {
            var model = new ProductsModel();
            if (dbobject != null)
            {
                model.ProductId = dbobject.ProductId;
                model.ProductName = dbobject.ProductName;
                model.ProductCategory = dbobject.Productcategory;
                model.ProductInUse = dbobject.ProductInUse;
            }
            return model;
        }

        private Product MapModelToDBOject(ProductsModel model)
        {
            var dbobject = new Product();
            if (model != null)
            {
                dbobject.ProductId = model.ProductId;
                dbobject.ProductName = model.ProductName;
                dbobject.Productcategory = model.ProductCategory;
                dbobject.ProductInUse = model.ProductInUse;
            }
            return dbobject;
        }

        private Product MapModelToDBOjectInsert(ProductsModel model)
        {
            var dbobject = new Product();
            if (model != null)
            {
                dbobject.ProductId = model.ProductId;
                dbobject.ProductName = model.ProductName;
                dbobject.Productcategory = model.ProductCategory;
                dbobject.ProductInUse = true;
            }
            return dbobject;
        }

        public List<ProductsModel> GetAllProducts()
        {
            var list = new List<ProductsModel>();

            foreach (var dboject in _DBContext.Products)
            {
                list.Add(MapDBObjectToModel(dboject));
            }
            return list;
        }

        public ProductsModel GetProductByID(Guid ID)
        {
            return MapDBObjectToModel(_DBContext.Products.FirstOrDefault(x => x.ProductId == ID));
        }

        public void InsertProduct(ProductsModel model)
        {
            model.ProductId = Guid.NewGuid();
            _DBContext.Products.Add(MapModelToDBOjectInsert(model));
            _DBContext.SaveChanges();
        }

        public void UpdateProduct(ProductsModel model)
        {
            var dbobject = _DBContext.Products.FirstOrDefault(x => x.ProductId == model.ProductId);
            if (dbobject != null)
            {
                dbobject.ProductId = model.ProductId;
                dbobject.ProductName = model.ProductName;
                dbobject.Productcategory = model.ProductCategory;
                dbobject.ProductInUse = model.ProductInUse;

                _DBContext.SaveChanges();
            }
        }

        public void DeleteProduct(Guid ID)
        {
            var dboject = _DBContext.Products.FirstOrDefault(x => x.ProductId == ID);
            if (dboject != null)
            {
                _DBContext.Products.Remove(dboject);
                _DBContext.SaveChanges();
            }
        }

    }
}
