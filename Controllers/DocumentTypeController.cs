using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockApp.Data;
using StockApp.Models;
using StockApp.Repository;
using System.Diagnostics.Metrics;

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
            var list = documentTypeRepository.GetAllDocumentTypes();
            return View(list);
        }

        // GET: DocumentTypeController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = documentTypeRepository.GetDocumentTypeByID(id);
            return View("DocumentTypeDetails", model);
        }

        // GET: DocumentTypeController/Create
        public ActionResult Create()
        {
            return View("DocumentTypeCreate");
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
                return RedirectToAction("Index");
            }
            catch
            {
                return View("");
            }
        }

        // GET: DocumentTypeController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = documentTypeRepository.GetDocumentTypeByID(id);
            return View("DocumentTypeEdit", model);
        }

        // POST: DocumentTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new DocumentTypeModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    documentTypeRepository.UpdateDocumentType(model);

                }


                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("DocumentTypeEdit");
            }
        }

        // GET: DocumentTypeController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = documentTypeRepository.GetDocumentTypeByID(id);
            return View("DocumentTypeDelete", model);
        }

        // POST: DocumentTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                documentTypeRepository.DeleteDocumentType(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Delete", id);
            }
        }
    }
}
