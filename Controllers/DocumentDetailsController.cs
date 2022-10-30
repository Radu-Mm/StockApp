using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockApp.Data;
using StockApp.Models;
using StockApp.Repository;

namespace StockApp.Controllers
{
    public class DocumentDetailsController : Controller
    {


        private DocumentDetailsRepository documentDetailsRepository;

        public DocumentDetailsController(ApplicationDbContext dbContext)
        {
            documentDetailsRepository = new DocumentDetailsRepository(dbContext);
        }


        // GET: DocumentDetailsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DocumentDetailsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DocumentDetailsController/Create
        public ActionResult Create()
        {
            return View("DocumentDetailsCreate");
        }

        // POST: DocumentDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new DocumentDetailsModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    documentDetailsRepository.InsertDocumentDetails(model);

                }
                // return RedirectToAction(nameof(Index));
                return View("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DocumentDetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DocumentDetailsController/Edit/5
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

        // GET: DocumentDetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DocumentDetailsController/Delete/5
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
