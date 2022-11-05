using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockApp.Data;
using StockApp.Models;
using StockApp.Repository;

namespace StockApp.Controllers
{
    public class UsageTypeController : Controller
    {
        private UsageTypeRepository usageTypeRepository;

        public UsageTypeController(ApplicationDbContext dbContext)
        {
            usageTypeRepository = new UsageTypeRepository(dbContext);
        }


        // GET: UsageTypeController
        public ActionResult Index()
        {
            var list = usageTypeRepository.GetAllUsageTypes();

            return View(list);
        }

        // GET: UsageTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsageTypeController/Create
        public ActionResult Create()
        {
            return View("UsageTypeCreate");
        }

        // POST: UsageTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new UsageTypeModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    usageTypeRepository.InsertUsageType(model);

                }


                return RedirectToAction("Index");

            }
            catch
            {
                return View("");
            }
        }

        // GET: UsageTypeController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = usageTypeRepository.GetUsageTypeByID(id);
            return View("UsageTypeEdit", model);
        }

        // POST: UsageTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new UsageTypeModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    usageTypeRepository.UpdateUsageTypes(model);

                }


                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Edit", id);
            }
        }

        // GET: UsageTypeController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = usageTypeRepository.GetUsageTypeByID(id);
            return View("UsageTypeDelete", model);
        }

        // POST: UsageTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                usageTypeRepository.DeleteUsageTypes(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Delete", id);
            }
        }
    }
}
