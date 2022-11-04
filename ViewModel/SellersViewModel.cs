using NuGet.Protocol.Core.Types;
using StockApp.Models;
using StockApp.Repository;

namespace StockApp.ViewModel
{
    public class SellersViewModel
    {

        public Guid SellerId { get; set; }
        public string? SellerName { get; set; }
        public string? SellerUic { get; set; }
        public Guid SellerCountry { get; set; } 
        public Guid SellerDistrict { get; set; }  
        public string? SellerAddress { get; set; }
        public string? SellerPhone { get; set; }
        public bool BlackListed { get; set; }
        public string? BlackListMotive { get; set; }
        public DateTime? BlackListTime { get; set; }
        public string? BlackListWho { get; set; }

        public string CountryName { get; set; } 
        public string DistrictName { get; set; }

        public SellersViewModel (SellersModel model, CountriesRepository country, DistrictsRepository district)
        {
            this.SellerId = model.SellerId;
            this.SellerName = model.SellerName;
            this.SellerUic = model.SellerUic;
            
            this.SellerCountry = model.SellerCountry;
            var CountryText = country.GetCountryByID(SellerCountry);
            this.CountryName = CountryText.CountryName;

            this.SellerDistrict = model.SellerDistrict;
            var DistrictText = district.GetDistrictByID(SellerDistrict);
            this.DistrictName = DistrictText.DistrictName;

            this.SellerAddress = model.SellerAddress;
            this.SellerPhone = model.SellerPhone;
            this.BlackListed = model.BlackListed;
            this.BlackListMotive = model.BlackListMotive;
            this.BlackListTime = model.BlackListTime;
            this.BlackListWho = model.BlackListWho;
        }
    }
}
