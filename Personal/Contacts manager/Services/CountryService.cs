using ServiceContracts;
using ServiceContracts.DTO;
using Entities;

namespace Services
{
    public class CountryService : ICountriesService
    {
        private readonly List<Country> _countries;
        //this is from the tester's perspective. He usually puts dummy or not implemented values
        public CountryService()
        {
            _countries = new();
        }
        public CountryResponse AddCountry(CountryAddRequest? request)
        {
            //Validation: if the request is null
            if(request == null)  throw new ArgumentNullException(nameof(request)); 

            //Validation: if CountryName is null
            if (request.CountryName == null)  throw new ArgumentException(nameof(request.CountryName)); 

            //Validation: if duplicate country names exist
            if(_countries.Where(country => country.CountryName.Equals(request.CountryName)).Any())  throw new ArgumentException("Country name already exists\n"); 

            //Convert CountryAddRequest object to Country type
            Country country = request.ToCountry();

            //Generate countryId
            country.CountryId= Guid.NewGuid();

            //Add object country into the list
            _countries.Add(country);

            //return object as an CountryResponse object
            return country.ToCountryResponse();
        }

        public List<CountryResponse> GetAllCountries()
        {
            return _countries.Select(country=> country.ToCountryResponse()).ToList();
        }

        public CountryResponse GetCountryByCountryID(Guid? countryId)
        {
            if(countryId == null)  return null;

            if (_countries.FirstOrDefault(country => country.CountryId.Equals(countryId)) is Country found) return found.ToCountryResponse();

            return null;
        }
    }
}