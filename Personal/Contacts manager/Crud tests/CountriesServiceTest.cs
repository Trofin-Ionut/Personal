using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using ServiceContracts.DTO;

namespace Crud_tests
{
    public class CountriesServiceTest
    {
        private readonly ICountriesService _countriesService;

        public CountriesServiceTest()
        {
            _countriesService = new CountryService();
        }

        #region AddCountry
        [Fact]  //unit test decorator => tells the IDE this is a test method
        //When CountryAddRequest == null => must throw ArgumentNullException
        public void AddCountry_NullCountry()   //normally, it is Arrange => Act => Assert (here Act is within the Assert stage)
        {
            //Arrange
            CountryAddRequest? request = null;

            //Assert
            //Act
            Assert.Throws<ArgumentNullException>(() => _countriesService.AddCountry(request)); //it's ok if it throws exception. that's what you are looking for when null
        }
        //When CountryName is null => ArgumentException

        [Fact]
        public void AddCountry_CountryNameIsNull()
        {
            CountryAddRequest request = new() { CountryName = null };

            Assert.Throws<ArgumentException>(() => _countriesService.AddCountry(request));
        }

        //When CountryName is duplicated => Argument Exception

        [Fact]
        public void AddCountry_DuplicateCountryName()
        {
            CountryAddRequest request1 = new() { CountryName = "Romania" };
            CountryAddRequest request2 = new() { CountryName = "Romania" };

            Assert.Throws<ArgumentException>(() =>
            {
                _countriesService.AddCountry(request1);
                _countriesService.AddCountry(request2);
            });
        }
        //When you supply country name, it should insert the country in the existing list of countries

        [Fact]
        public void AddCountry_ProperCountryDetails()
        {
            //Assert
            CountryAddRequest request = new() { CountryName = "USA" };
            //Act
            CountryResponse response = _countriesService.AddCountry(request); //in a context where you're testing something THAT WORKS, you use the CountryResponse
            //Assert 
            Assert.True(response.CountryId != Guid.Empty);
        }
        #endregion

        #region GetAllCountries
        [Fact]
        //The list of countries should be empty by default before adding any country
        public void GetAllCountries_EmptyList()
        {
            //Arrange (sometimes, arrange and Act can be combined, especially here, since you're testing a container
            //Act
            List<CountryResponse> countryReponseList = _countriesService.GetAllCountries();

            //Assert
            Assert.Empty(countryReponseList);
        }
        // you need to use the Request class from the DTO when you're testing stuff, not the model class directly here.
        [Fact]
        public void GetAllCountries_AddSomeCountries()
        {
            //Arrange
            List<CountryAddRequest> requestList = new() { new() { CountryName = "Romania" }, new() { CountryName = "Ucraina" } };
            List<CountryResponse> listFromAddCountries = new();

            //Act
            foreach (CountryAddRequest request in requestList)
            {
                listFromAddCountries.Add(_countriesService.AddCountry(request));
            }
            List<CountryResponse> listFromGetCountry = _countriesService.GetAllCountries();
            //Assert
            foreach (CountryResponse countryAddRequest in listFromAddCountries)
            {
                Assert.Contains(countryAddRequest, listFromGetCountry);
            }
        }
        [Fact]
        public void GetAllCountries_ProperCountryDetails()
        {
            //Arrange
            CountryAddRequest request = new() { CountryName = "Georgia" };

            //Act
            CountryResponse response = _countriesService.AddCountry(request);
            List<CountryResponse> countriesFromGetCountry = _countriesService.GetAllCountries();

            //Assert
            Assert.True(response.CountryId != Guid.Empty);
            Assert.Contains(response, countriesFromGetCountry); //Assert.Contains uses the class's Equals method, reason why it was needed to override it
        }
        #endregion

        #region GetCountryByCountryId

        [Fact]
        //If the id is null, the object returned should be null aswell
        public void GetCountryByCountryId_NullCountryId()
        {
            //Arrange
            Guid? countryId = null;

            //Act
            CountryResponse? response=_countriesService.GetCountryByCountryID(countryId);

            //Assert
            Assert.Null(response);
        }

        [Fact]
        //If the id is valid, it should return the matching object (note, you can't just get the country response directly,
        //you need to do it throgh CountryAddRequest using AddCountry method.
        //The object becomes valid once added with AddCoutry method. => addrequest ->response
        public void GetCountryByCountryId_ValidCountryId()
        {
            //Arrange
            CountryAddRequest? request= new() {CountryName="Moldova" } ;
            CountryResponse AddCountryResponse = _countriesService.AddCountry(request);

            //Act
            CountryResponse? response= _countriesService.GetCountryByCountryID(AddCountryResponse.CountryId);

            //Assert
            Assert.True(response.CountryId.Equals(AddCountryResponse.CountryId));
        }
        #endregion
    }
}
