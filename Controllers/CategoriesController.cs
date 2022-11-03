using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockApp.Data;
using StockApp.Models;
using StockApp.Repository;
using System.ComponentModel;

namespace StockApp.Controllers
{
    public class CategoriesController : Controller
    {

        private CategoriesRepository categoryRepository;

        public CategoriesController(ApplicationDbContext dbContext)
        {
            categoryRepository = new CategoriesRepository(dbContext);
        }

        // GET: CategoriesController
        public ActionResult Index()
        {
            var list = categoryRepository.GetAllCategories();
            return View(list);
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = categoryRepository.GetCategoryByID(id);
            return View("CategoryDetails", model);
        }

        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View("CategoryCreate");
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new CategoriesModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    categoryRepository.InsertCategory(model);

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View("");
            }
        }

        // GET: CategoriesController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = categoryRepository.GetCategoryByID(id);
            return View("CategoryEdit", model);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new CategoriesModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    categoryRepository.UpdateCategory(model);

                }


                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Edit", id);
            }
        }

        // GET: CategoriesController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = categoryRepository.GetCategoryByID(id);
            return View("CategoryDelete", model);
        }

        // POST: CategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {

            try
            {
                categoryRepository.DeleteCategory(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Delete", id);
            }
        }
    }
}
