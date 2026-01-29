namespace MW_SOLUCOES.Entities;

public class ClientName
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public ClientName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string GetFullName()
    {
        string fullName = $"{FirstName} {FirstName}";
        return fullName;
    }
}
