using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StockApp.Data;
using StockApp.Models;
using StockApp.Repository;
using StockApp.ViewModel;

namespace StockApp.Controllers
{
    public class ProductsController : Controller
    {

        private ProductsRepository productsRepository;
        private CategoriesRepository categoriesRepository;

        public ProductsController(ApplicationDbContext dbContext)
        {
            categoriesRepository = new CategoriesRepository(dbContext);
            productsRepository = new ProductsRepository(dbContext);
        }

        // GET: ProductsController
        public ActionResult Index()
        {
            var list = productsRepository.GetAllProducts();
            var viewmodellist = new List<ProductsViewModel>();
            foreach (var products in list)
            {
                viewmodellist.Add(new ProductsViewModel(products, categoriesRepository));
            }

            return View(viewmodellist);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(Guid id)
        {

            var model = productsRepository.GetProductByID(id);
            return View("ProductDetails", model);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            var categories = categoriesRepository.GetAllCategories();
            var getCategories = categories.Select(x => new SelectListItem(x.CategoyName, x.CategoryId.ToString()));
            ViewBag.Categories = getCategories;

            return View("ProductsCreate");

        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new ProductsModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    productsRepository.InsertProduct(model);

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View("ProductsCreate");
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = productsRepository.GetProductByID(id);
            var categories = categoriesRepository.GetAllCategories();
            var getCategories = categories.Select(x => new SelectListItem(x.CategoyName, x.CategoryId.ToString()));
            ViewBag.Categories = getCategories;
            return View("ProductEdit", model);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new ProductsModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    productsRepository.UpdateProduct(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("ProductEdit");
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = productsRepository.GetProductByID(id);
            return View("ProductDelete", model);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                productsRepository.DeleteProduct(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Delete");
            }
        }
    }
}
