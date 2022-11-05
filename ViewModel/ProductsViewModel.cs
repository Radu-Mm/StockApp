using StockApp.Models;
using StockApp.Repository;

namespace StockApp.ViewModel
{
    public class ProductsViewModel
    {
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public Guid ProductCategory { get; set; }
        public bool ProductInUse { get; set; }

        public string CategoryName { get; set; }

        public ProductsViewModel (ProductsModel model, CategoriesRepository categories)
        {
            this.ProductId = model.ProductId;
            this.ProductName = model.ProductName;
            this.ProductCategory=model.ProductCategory;
            var catname = categories.GetCategoryByID(ProductCategory);
            this.CategoryName = catname.CategoyName;
            this.ProductInUse = model.ProductInUse;
        }
    }
}
