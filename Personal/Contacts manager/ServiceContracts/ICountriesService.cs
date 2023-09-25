using ServiceContracts.DTO;

namespace ServiceContracts
{/// <summary> => this xml content displays as tooltip when hovering over the structure/method used in the actual code
/// Represents business logic for manipulating Country entity
/// </summary>
    public interface ICountriesService
    {
        /// <summary>
        /// Adds a country object to the list of countries
        /// </summary>
        /// <param name="request"></param>
        /// <returns>
        /// Returns the country object after adding it(including newly generated CountryId)
        /// </returns>
        CountryResponse AddCountry(CountryAddRequest? request);
        /// <summary>
        /// Returns all countries from the list
        /// </summary>
        /// <returns></returns>
        List<CountryResponse> GetAllCountries();
        /// <summary>
        /// Returns a country object based by thw given country id
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns>Matching object as CountryResponse object</returns>
        CountryResponse GetCountryByCountryID(Guid? countryId);
    }
}