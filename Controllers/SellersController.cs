using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StockApp.Data;
using StockApp.Models;
using StockApp.Repository;
using StockApp.ViewModel;

namespace StockApp.Controllers
{
    public class SellersController : Controller
    {

        private SellersRepository sellersRepository;
        private CountriesRepository countriesRepository;
        private DistrictsRepository districtsRepository;

        public SellersController(ApplicationDbContext dbContext)
        {
            sellersRepository = new SellersRepository(dbContext);
            countriesRepository = new CountriesRepository(dbContext);
            districtsRepository = new DistrictsRepository(dbContext);
        }

        // GET: SellersController
        public ActionResult Index()
        {
            var list = sellersRepository.GetAllSellers();
            var viewmodellist = new List<SellersViewModel>();
            foreach (var sellers in list)
            {
                viewmodellist.Add(new SellersViewModel(sellers, countriesRepository, districtsRepository));
            }

            return View(viewmodellist);
        }

        // GET: SellersController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = sellersRepository.GetSellerByID(id);
            return View("SellerDetails", model);
        }

        // GET: SellersController/Create
        public ActionResult Create()
        {
            var countries = countriesRepository.GetAllCountries();
            var getCountries = countries.Select(x => new SelectListItem(x.CountryName, x.CountryId.ToString()));
            ViewBag.Countries = getCountries;

            var districts = districtsRepository.GetAllDistricts();
            var getDistricts = districts.Select(x => new SelectListItem(x.DistrictName, x.DistrictId.ToString()));
            ViewBag.Districts = getDistricts;

            return View("SellersCreate");
 
        }

        // POST: SellersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new SellersModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    sellersRepository.InsertSeller(model);

                }
         
                return RedirectToAction("Index");
            }
            catch
            {
                return View("SellersCreate");
            }
        }

        // GET: SellersController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = sellersRepository.GetSellerByID(id);
            var districts = districtsRepository.GetAllDistricts();
            var countries = countriesRepository.GetAllCountries();
            var getDistricts = districts.Select(x => new SelectListItem(x.DistrictName, x.DistrictId.ToString()));
            var getCountries = countries.Select(x => new SelectListItem(x.CountryName, x.CountryId.ToString()));
            ViewBag.Countries = getCountries;
            ViewBag.Districts = getDistricts;
            return View("SellerEdit", model);
        }

        // POST: SellersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
            var model = new SellersModel();
            var task = TryUpdateModelAsync(model);
            task.Wait();
            if (task.Result)
            {
                sellersRepository.UpdateSeller(model);
            }
       
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("SellerEdit");
            }
        }

        // GET: SellersController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = sellersRepository.GetSellerByID(id);
            return View("SellerDelete", model);
        }

        // POST: SellersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            var countries = countriesRepository.GetAllCountries();
            var getCountries = countries.Select(x => new SelectListItem(x.CountryName, x.CountryId.ToString()));
            ViewBag.Countries = getCountries;

            var districts = districtsRepository.GetAllDistricts();
            var getDistricts = districts.Select(x => new SelectListItem(x.DistrictName, x.DistrictId.ToString()));
            ViewBag.Districts = getDistricts;


            try
            {
                sellersRepository.DeleteSeller(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Delete", id);
            }
        }
    }
}
