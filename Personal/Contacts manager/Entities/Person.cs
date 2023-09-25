using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Person
    {
        public Guid PersonId { get; set; }
        public string? PersonName { get; set; }
        public string? Email { get; set;}
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public Guid? CountryId { get; set; } //foreign key
        public string? Address { get; set; }
        public bool ReceiveNewsLetters { get; set; }

        public Person(Guid personId, string? personName, string? email, DateTime? dateOfBirth, string? gender, Guid? countryId, string? address, bool receiveNewsLetters)
        {
            PersonId = personId;
            PersonName = personName;
            Email = email;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            CountryId = countryId;
            Address = address;
            ReceiveNewsLetters = receiveNewsLetters;
        }
        public Person(string? personName, string? email, DateTime? dateOfBirth, string? gender, Guid? countryId, string? address, bool receiveNewsLetters)
        {
            PersonName = personName;
            Email = email;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            CountryId = countryId;
            Address = address;
            ReceiveNewsLetters = receiveNewsLetters;
        }
    }
}
