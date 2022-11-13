using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StockApp.Data;
using StockApp.Models;
using StockApp.Repository;
using StockApp.ViewModel;

namespace StockApp.Controllers
{
    public class DocumentDetailsController : Controller
    {


        private DocumentDetailsRepository documentDetailsRepository;
        private DocumentsRepository documentsRepository;
        private ProductsRepository productsRepository;

        public DocumentDetailsController(ApplicationDbContext dbContext)
        {
            documentDetailsRepository = new DocumentDetailsRepository(dbContext);
            documentsRepository = new DocumentsRepository(dbContext);
            productsRepository = new ProductsRepository(dbContext);
        }


        // GET: DocumentDetailsController
        public ActionResult Index()
        {
 

            var list = documentDetailsRepository.GetAllDocumentDetails();
            var viewmodellist = new List<DocumentDetailsViewModel>();
            foreach (var document in list)
            {
                viewmodellist.Add(new DocumentDetailsViewModel(document, documentsRepository, productsRepository));
            }

            return View(viewmodellist);
        }

        // GET: DocumentDetailsController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = documentDetailsRepository.GetDocumentDetailByID(id);
            return View("DocumentDetDetails", model);
        }

        // GET: DocumentDetailsController/Create
        public ActionResult Create()
        {
       
            var products = productsRepository.GetAllProducts();
            var getProducts = products.Select(x => new SelectListItem(x.ProductName, x.ProductId.ToString()));
            ViewBag.Products = getProducts;

            var documents = documentsRepository.GetAllDocuments();
            var getDocuments = documents.Select(x => new SelectListItem(x.DocNumber, x.DocId.ToString()));
            ViewBag.Documents = getDocuments;

   
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
                //   if (task.Result)
                //   {
                documentDetailsRepository.InsertDocumentDetails(model);
      
                    documentDetailsRepository.updateQuantityRemaining(model);
          
                //   }

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DocumentDetailsCreate");
            }
        }

        // GET: DocumentDetailsController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = documentDetailsRepository.GetDocumentDetailByID(id);
            var products = productsRepository.GetAllProducts();
            var getProducts = products.Select(x => new SelectListItem(x.ProductName, x.ProductId.ToString()));
            ViewBag.Products = getProducts;

            var documents = documentsRepository.GetAllDocuments();
            var getDocuments = documents.Select(x => new SelectListItem(x.DocNumber, x.DocId.ToString()));
            ViewBag.Documents = getDocuments;

            return View("DocumentDetailsEdit", model);
        }

        // POST: DocumentDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new DocumentDetailsModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
              //  if (task.Result)
              //  {
                    documentDetailsRepository.UpdateDocumentDetails(model);
                //de scos dupa implementare iesiri
                    documentDetailsRepository.updateQuantityRemaining(model);
                //  }

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("DocumentDetailsEdit");
            }
        }

        // GET: DocumentDetailsController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = documentDetailsRepository.GetDocumentDetailByID(id);
            return View("DocumentDetailsDelete", model);
        }

        // POST: DocumentDetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                documentDetailsRepository.DeleteDocumentDetails(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Delete");
            }
        }
    }
}
