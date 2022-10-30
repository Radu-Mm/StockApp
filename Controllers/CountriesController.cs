using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using NuGet.Protocol.Plugins;
using StockApp.Data;
using StockApp.Models;
using StockApp.Repository;

namespace StockApp.Controllers
{
    public class CountriesController : Controller
    {


        private CountriesRepository countriesRepository;

        public CountriesController(ApplicationDbContext dbContext)
        {
            countriesRepository = new CountriesRepository(dbContext);
        }



        // GET: CountriesController
        public ActionResult Index()
        {
            var list = countriesRepository.GetAllCountries();

            return View(list);
        }

        // GET: CountriesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CountriesController/Create
        public ActionResult Create()
        {
            return View("CreateCountry");
        }

        // POST: CountriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {

            try
            {
                 var model = new CountriesModel();
                 var task =  TryUpdateModelAsync(model);
                 task.Wait();
                 if (task.Result)
                {
                     countriesRepository.InsertCountry(model);

                }
                 
                // return RedirectToAction(nameof(Index));
                return View("Index");
              //  MessageBox.Show("Tara a fost adaugata.");
            }
            catch
            {
                return View("");
            }
        }

 

        // GET: CountriesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CountriesController/Edit/5
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

        // GET: CountriesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CountriesController/Delete/5
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
