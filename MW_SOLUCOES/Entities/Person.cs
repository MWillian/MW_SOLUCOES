namespace MW_SOLUCOES.Entities;

using MW_SOLUCOES.Exceptions;
using MW_SOLUCOES.Helpers;

public class Person
{
    public Guid Id { get; private set; }
    public ClientName Name { get; private set; }
    public int Age { get; private set; }
    public string CPF { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public Address Address { get; private set; }

    public Person(Guid id, ClientName name, int age, string cpf, string phone, Address address)
    {
        Id = id;
        Name = name;
        Age = age;
        CPF = cpf;
        Phone = phone;
        Address = address;
    }
    public void UpdateName(string firstName, string lastName)
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
        {
            throw new NegocioException("Primeiro ou último nome estão em branco.");
        }
        Name.FirstName = firstName;
        Name.LastName = lastName;
    }
    public void UpdateAge(int age)
    {
        if (age < 0 || age > 130)
        {
            throw new NegocioException("Idade fora dos padrões aceitáveis.");
        }
        Age = age;
    }
    public void UpdateContactInfo(string email,string phone)
    {
        if (!EmailValidationHelper.IsValidEmail(email))
        {
            throw new NegocioException("Email inválido.");
        }
        Email = email;
        if (Phone.Length == 13)
        {
            Phone = phone;
        }
        else
        {
            throw new NegocioException("O número de telefone inserido é inválido");
        }
    }
}
