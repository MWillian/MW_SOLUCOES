using System.Runtime.ConstrainedExecution;

namespace MW_SOLUCOES.Entities;

public class Address
{
    private string StreetName { get; set; } = string.Empty;
    private string City { get; set; } = string.Empty;
    private string Country { get; set; } = string.Empty;
    private string State = string.Empty;
    private string HouseNumber = string.Empty;
    private string CEP = string.Empty;

    public Address(string streetName, string city, string country, string state, string houseNumber,string cep)
    {
        StreetName = streetName;
        City = city;
        Country = country;
        State = state;
        HouseNumber = houseNumber;
        CEP = cep;
    }
}
