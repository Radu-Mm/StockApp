using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StockApp.Data;
using StockApp.Models;
using StockApp.Repository;
using StockApp.ViewModel;

namespace StockApp.Controllers
{
    public class UsageController : Controller
    {
        private UsageRepository usageRepository;
        private UsageTypeRepository usageTypeRepository;
        private ProductsRepository productsRepository;
        private DocumentDetailsRepository documentDetailsRepository;
        private DocumentsRepository documentsRepository;

        public UsageController(ApplicationDbContext dbContext)
        {
            usageRepository = new UsageRepository(dbContext);
            usageTypeRepository = new UsageTypeRepository(dbContext);
            productsRepository = new ProductsRepository(dbContext);
            documentsRepository = new DocumentsRepository(dbContext);
        }


        // GET: UsageController
        public ActionResult Index()
        {
            var list = usageRepository.GetAllUsage();
            var viewmodellist = new List<UsageViewModel>();
            foreach (var usage in list)
            {
                viewmodellist.Add(new UsageViewModel(usage, usageTypeRepository, documentDetailsRepository, productsRepository, documentsRepository));
            }

            return View(viewmodellist);
        }

        // GET: UsageController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = usageRepository.GetUsageByID(id);
            return View("UsageDetails", model);
        }

        // GET: UsageController/Create
        public ActionResult Create()
        {
            var products = productsRepository.GetAllProducts();
            var getProducts = products.Select(x => new SelectListItem(x.ProductName, x.ProductId.ToString()));
            ViewBag.Products = getProducts;

            var documents = documentsRepository.GetAllDocuments();
            var getDocuments = documents.Select(x => new SelectListItem(x.DocNumber, x.DocId.ToString()));
            ViewBag.Documents = getDocuments;

            var usagetype = usageTypeRepository.GetAllUsageTypes();
            var getUsageType = usagetype.Select(x => new SelectListItem(x.UsageType1, x.UsageTypeId.ToString()));
            ViewBag.UsageType = getUsageType;


            return View("UsageCreate");
        }

        // POST: UsageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new UsageModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                   if (task.Result)
                   {
                    usageRepository.InsertUsage(model);
                   }

                return RedirectToAction("Index");
            }
            catch
            {
                return View("UsageCreate");
            }
        }

        // GET: UsageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsageController/Edit/5
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

        // GET: UsageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsageController/Delete/5
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
