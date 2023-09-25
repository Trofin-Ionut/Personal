using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PersonService : IPersonService
    {
        private readonly List<Person> _persons;
        private readonly ICountriesService _countryService;

        public PersonService() 
        { 
            _persons = new List<Person>(); 
            _countryService = new CountryService(); 
        }

        public PersonResponse AddPerson(PersonAddRequest request)
        {
            if(request == null) throw new ArgumentNullException(nameof(request));
            if(request.PersonName==null || request.PersonName.Equals("")) throw new ArgumentException("Person's name is empty");

            Person person = request.ToPerson();

            person.PersonId=Guid.NewGuid();

            _persons.Add(person);

            return person.ToPersonResponse();
        }

        public List<PersonResponse> GetPeople()
        {
            throw new NotImplementedException();
        }
    }
}
