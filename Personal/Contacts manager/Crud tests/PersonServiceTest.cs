using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ServiceContracts;
using Services;
using ServiceContracts.DTO;
using ServiceContracts.Enums;

namespace Crud_tests
{
    public class PersonServiceTest
    {
        private readonly IPersonService _personService;

        public PersonServiceTest() => _personService = new PersonService();

        [Fact]
        public void AddPerson_NullPerson()
        {
            //Arrange
            PersonAddRequest? request = null;

            //Act+Assert
            Assert.Throws<ArgumentNullException>(() => _personService.AddPerson(request));
        }
        public void AddPerson_NullPersonName()
        {
            PersonAddRequest? request = new() { PersonName = null };

            Assert.Throws<ArgumentException>(() => _personService.AddPerson(request));
        }
        public void AddPerson_ProperPersonDetails()
        {
            //Arrange
            PersonAddRequest? request = new()
            {
                PersonName = "Johnny",
                Address = "St. Pain",
                CountryId = Guid.NewGuid(),
                DateOfBirth = DateTime.Now,
                Email = "lala.lulu@stupid.com",
                Gender = GenderOptions.Male,
                ReceiveNewsLetters = false
            };

            //Act
            PersonResponse response = _personService.AddPerson(request);

            //Assert => you just want to see if it was added. Reason why you check if the new property isn't empty.
            Assert.True(response.PersonId != Guid.Empty);
        }
    }
}
