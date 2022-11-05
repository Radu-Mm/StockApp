using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StockApp.Data;
using StockApp.Models;
using StockApp.Repository;
using StockApp.ViewModel;

namespace StockApp.Controllers
{
    public class DocumentsController : Controller
    {

        private DocumentsRepository documentsRepository;
        private SellersRepository sellersRepository;
        private DocumentTypeRepository documentTypeRepository;

        public DocumentsController(ApplicationDbContext dbContext)
        {
            documentsRepository = new DocumentsRepository(dbContext);
            sellersRepository = new SellersRepository(dbContext);
            documentTypeRepository = new DocumentTypeRepository(dbContext);
        }

        // GET: DocumentsController
        public ActionResult Index()
        {
            var list = documentsRepository.GetAllDocuments();
            var viewmodellist = new List<DocumentsViewModel>();
            foreach (var documents in list)
            {
                viewmodellist.Add(new DocumentsViewModel(documents, sellersRepository, documentTypeRepository));
            }

            return View(viewmodellist);
            
        }

        // GET: SellersController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = documentsRepository.GetDocumentByID(id);
            return View("DocumentDetails", model);
        }

        // GET: DocumentsController/Details/5
        public ActionResult Create()
        {
            var sellers = sellersRepository.GetAllSellers();
            var getSellers = sellers.Select(x => new SelectListItem(x.SellerName, x.SellerId.ToString()));
            ViewBag.Sellers = getSellers;

            var docs = documentTypeRepository.GetAllDocumentTypes();
            var getdocs = docs.Select(x => new SelectListItem(x.DocType, x.DocTypeId.ToString()));
            ViewBag.docs = getdocs;


            return View("DocumentsCreate");

        }

        // POST: SellersController/Create
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

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DocumentsCreate");
            }
        }

        // GET: DocumentsController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = documentsRepository.GetDocumentByID(id);
            var sellers = sellersRepository.GetAllSellers();
            var doctypes = documentTypeRepository.GetAllDocumentTypes();
            var getSellers = sellers.Select(x => new SelectListItem(x.SellerName, x.SellerId.ToString()));
            var getDocTypes = doctypes.Select(x => new SelectListItem(x.DocType, x.DocTypeId.ToString()));
            ViewBag.Sellers = getSellers;
            ViewBag.DocTypes = getDocTypes;
            return View("DocumentEdit", model);
             
        }

        // POST: DocumentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new DocumentsModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    documentsRepository.UpdateDocument(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("DocumentEdit");
            }
        }

        // GET: DocumentsController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = documentsRepository.GetDocumentByID(id);
            return View("DocumentDelete", model);
        }

        // POST: DocumentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                documentsRepository.DeleteDocument(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Delete");
            }
        }
    }
}
