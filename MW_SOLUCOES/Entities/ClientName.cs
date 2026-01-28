namespace MW_SOLUCOES.Entities;

public class ClientName
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public string GetFullName()
    {
        string fullName = $"{FirstName} {FirstName}";
        return fullName;
    }
}
