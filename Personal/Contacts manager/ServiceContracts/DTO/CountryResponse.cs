using Entities;

namespace ServiceContracts.DTO
{/// <summary>
/// A DTO class that is used as a return type for most CountryService methods
/// </summary>
    public class CountryResponse
    {
        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }

        public override bool Equals(object? obj)
        {
            if(obj is null) {return false;}
            if(obj is not CountryResponse response) { return false; }

            return CountryId.Equals(response.CountryId);
        }
        //formal override (because you overrided Equals method)
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public static class CountryExtensions
    {
        //extension method => acts as if this method exists in the Country class itself : this [className] makes it like this  
        public static CountryResponse ToCountryResponse(this Country response) 
        {
            return new CountryResponse { CountryId = response.CountryId, CountryName = response.CountryName };
        }
    }

}
