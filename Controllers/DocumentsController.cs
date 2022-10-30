using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockApp.Data;
using StockApp.Models;
using StockApp.Repository;

namespace StockApp.Controllers
{
    public class DocumentsController : Controller
    {

        private DocumentsRepository documentsRepository;

        public DocumentsController(ApplicationDbContext dbContext)
        {
            documentsRepository = new DocumentsRepository(dbContext);
        }

        // GET: DocumentsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DocumentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DocumentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new DocumentsModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    documentsRepository.InsertDocument(model);

                }
                // return RedirectToAction(nameof(Index));
                return View("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DocumentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DocumentsController/Edit/5
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

        // GET: DocumentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DocumentsController/Delete/5
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
