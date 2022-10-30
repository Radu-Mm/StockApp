using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockApp.Data;
using StockApp.Models;
using StockApp.Repository;

namespace StockApp.Controllers
{
    public class DistrictsController : Controller
    {


        private DistrictsRepository districtsRepository;

        public DistrictsController(ApplicationDbContext dbContext)
        {
            districtsRepository = new DistrictsRepository(dbContext);
        }


        // GET: DistrictsController
        public ActionResult Index()
        {
            var list = districtsRepository.GetAllDistricts();
            return View(list);
        }

        // GET: DistrictsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DistrictsController/Create
        public ActionResult Create()
        {
            return View("DistrictCreate");
        }

        // POST: DistrictsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new DistrictsModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    districtsRepository.InsertDistrict(model);
                }
                // return RedirectToAction(nameof(Index));
                return View("DistrictCreate");
 
            }
            catch
            {
                return View();
            }
        }

        // GET: DistrictsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DistrictsController/Edit/5
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

        // GET: DistrictsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DistrictsController/Delete/5
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
