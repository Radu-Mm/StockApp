using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockApp.Data;
using StockApp.Models;
using StockApp.Repository;

namespace StockApp.Controllers
{
    public class SellersController : Controller
    {

        private SellersRepository sellersRepository;

        public SellersController(ApplicationDbContext dbContext)
        {
            sellersRepository = new SellersRepository(dbContext);
        }

        // GET: SellersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SellersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SellersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SellersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new SellersModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    sellersRepository.InsertSeller(model);

                }
                // return RedirectToAction(nameof(Index));
                return View("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SellersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SellersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SellersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SellersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
