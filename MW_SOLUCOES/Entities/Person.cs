namespace MW_SOLUCOES.Entities;

using MW_SOLUCOES.Exceptions;
using MW_SOLUCOES.Helpers;

public class Person
{
    public int Id { get; private set; }
    public PersonName Name { get; private set; }
    public int Age { get; private set; }
    public string CPF { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public Address Address { get; private set; }

    public Person(int id, PersonName name, int age, string cpf, string phone, Address address, string email)
    {
        Id = id;
        UpdateName(name.FirstName, name.LastName);
        UpdateAge(age);
        UpdateCpf(cpf);
        UpdatePhone(phone);
        UpdateAddress(address);
        UpdateEmail(email);
    }
    public void UpdateName(string newFirstName, string newLastName)
    {
        if (string.IsNullOrEmpty(newFirstName) || string.IsNullOrEmpty(newLastName))
        {
            throw new NegocioException("Primeiro ou último nome estão em branco.");
        }
        Name = new PersonName(newFirstName, newLastName);
    }
    public void UpdateAge(int newAge)
    {
        if (newAge < 0 || newAge > 130)
        {
            throw new NegocioException("Idade fora dos padrões aceitáveis.");
        }
        Age = newAge;
    }
    public void UpdateEmail(string newEmail)
    {
        if (!EmailValidationHelper.IsValidEmail(newEmail))
        {
            throw new NegocioException("Email inválido.");
        }
        Email = newEmail;
    }

    public void UpdatePhone(string newPhone)
    {
        if (newPhone.Length == 13)
        {
            Phone = newPhone;
        }
        else
        {
            throw new NegocioException("O número de telefone inserido é inválido");
        }

    }

    public void UpdateCpf(string rawCpf)
    {
        string formatedCpf = CPFValidationHelper.RemoveFormat(rawCpf);
        if (CPFValidationHelper.IsValid(formatedCpf))
        {
            CPF = formatedCpf;
        }
        else
        {
            throw new NegocioException("O CPF é inválido.");
        }
    }
    public void UpdateAddress(Address newAddress)
    {
        Address = newAddress;   
    }
    public void AssignId(int id)
    {
        if (id != 0)
        {
            throw new NegocioException("Não é possível atribuir um ID para um cliente já existente.");
        }
        if (id <= 0)
        {
            throw new NegocioException("Não é possível atribuir um ID negativo.");
        }
        Id = id;
    }
}
