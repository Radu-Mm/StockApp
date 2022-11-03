using Microsoft.EntityFrameworkCore;
using StockApp.Data;
using StockApp.Models;
using StockApp.Models.DBObjects;

namespace StockApp.Repository
{
    public class CategoriesRepository
    {
    
    private readonly ApplicationDbContext _DBContext;

    public CategoriesRepository()
    {
        _DBContext = new ApplicationDbContext();
    }

    public CategoriesRepository(ApplicationDbContext dbContext)
    {
        _DBContext = dbContext;
    }

        private CategoriesModel MapDBObjectToModel(Category dbobject)
        {
            var model = new CategoriesModel();
            if (dbobject != null)
            {
                model.CategoryId = dbobject.CategoryId;
                model.CategoyName = dbobject.CategoyName;
                model.CategoryDescription = dbobject.CategoryDescription;
            }
            return model;
        } 

        private Category MapModelToDBOject(CategoriesModel model)
        {
            var dbobject = new Category();
            if (model != null)
            {
                dbobject.CategoryId = model.CategoryId;
                dbobject.CategoyName = model.CategoyName;
                dbobject.CategoryDescription = model.CategoryDescription;
            }
            return dbobject;
        }

        public List<CategoriesModel> GetAllCategories()
        {
            var list = new List<CategoriesModel>();

            foreach (var dboject in _DBContext.Categories)
            {
                list.Add(MapDBObjectToModel(dboject));
            } return list;
        }

        public CategoriesModel GetCategoryByID(Guid ID)
        {
            return MapDBObjectToModel(_DBContext.Categories.FirstOrDefault(x => x.CategoryId == ID));
        }

        public void InsertCategory(CategoriesModel model)
        {
            model.CategoryId = Guid.NewGuid();
            _DBContext.Categories.Add(MapModelToDBOject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateCategory(CategoriesModel model)
        {
            var dbobject = _DBContext.Categories.FirstOrDefault(x => x.CategoryId == model.CategoryId);
            if (dbobject != null)
            {
                dbobject.CategoryId = model.CategoryId;
                dbobject.CategoyName = model.CategoyName;
                dbobject.CategoryDescription = model.CategoryDescription;

                _DBContext.SaveChanges();
            } 
        }

        public void DeleteCategory(Guid ID)
        {
            var dboject = _DBContext.Categories.FirstOrDefault(x => x.CategoryId == ID);
            if (dboject != null)
            {
 
                _DBContext.Categories.Remove(dboject);
                _DBContext.SaveChanges();
            }
        }
    }
}
