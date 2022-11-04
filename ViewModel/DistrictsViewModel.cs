using StockApp.Models;
using StockApp.Repository;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace StockApp.ViewModel
{
    public class DistrictsViewModel
    {
        public Guid DistrictId { get; set; }
        [Display(Name = "Nume Judet/District")]
        public string DistrictName { get; set; } = null!;

        [Display(Name = "Country Name")]
        public Guid CountryId { get; set; }

        public string CountryName { get; set; } = null!;


        public DistrictsViewModel(DistrictsModel model, CountriesRepository repository)
        {
            this.DistrictId = model.DistrictId;
            this.DistrictName = model.DistrictName;

            var country = repository.GetCountryByID(model.CountryId);
            this.CountryName = country.CountryName;
        }

    }
}
