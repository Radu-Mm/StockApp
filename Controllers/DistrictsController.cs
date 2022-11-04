using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockApp.Data;
using StockApp.Models;
using StockApp.Repository;
using StockApp.ViewModel;
using System.Runtime.CompilerServices;

namespace StockApp.Controllers
{
    public class DistrictsController : Controller
    {


        private DistrictsRepository districtsRepository;
        private CountriesRepository countriesRepository; 
        public DistrictsController(ApplicationDbContext dbContext)
        {
            countriesRepository = new CountriesRepository(dbContext);
            districtsRepository = new DistrictsRepository(dbContext);
        }


        // GET: DistrictsController
        public ActionResult Index()
        {

            var list = districtsRepository.GetAllDistricts();
            var viewmodellist = new List<DistrictsViewModel>();
            foreach (var district in list)
            {
                viewmodellist.Add(new DistrictsViewModel(district,countriesRepository));
            }

            return View(viewmodellist);

        }

        // GET: DistrictsController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = districtsRepository.GetDistrictByID(id);
            return View("DistrictDetails", model);
        }

        // GET: DistrictsController/Create
        public ActionResult Create()
        {
            var countries = countriesRepository.GetAllCountries() ;
            var getCountries = countries.Select(x => new SelectListItem(x.CountryName, x.CountryId.ToString()));
            ViewBag.Countries = getCountries;
      

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
                
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: DistrictsController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = districtsRepository.GetDistrictByID(id);
            var countries = countriesRepository.GetAllCountries();
            var getCountries = countries.Select(x => new SelectListItem(x.CountryName, x.CountryId.ToString()));
            ViewBag.Countries = getCountries;
            return View("DistrictEdit", model);
        }

        // POST: DistrictsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new DistrictsModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    districtsRepository.UpdateDistrict(model);

                }


                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Edit", id);
            }
        }

        // GET: DistrictsController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = districtsRepository.GetDistrictByID(id);
            return View("DistrictDelete", model);
        }

        // POST: DistrictsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                districtsRepository.DeleteDistrict(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Delete", id);
            }
        }
    }
}
