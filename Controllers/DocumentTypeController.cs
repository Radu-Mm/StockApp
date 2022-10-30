using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockApp.Data;
using StockApp.Models;
using StockApp.Repository;

namespace StockApp.Controllers
{
    public class DocumentTypeController : Controller
    {
        private DocumentTypeRepository documentTypeRepository;

        public DocumentTypeController(ApplicationDbContext dbContext)
        {
            documentTypeRepository = new DocumentTypeRepository(dbContext);
        }

        // GET: DocumentTypeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DocumentTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DocumentTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new DocumentTypeModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    documentTypeRepository.InsertDocumentType(model);

                }
                // return RedirectToAction(nameof(Index));
                return View("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DocumentTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DocumentTypeController/Edit/5
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

        // GET: DocumentTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DocumentTypeController/Delete/5
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
