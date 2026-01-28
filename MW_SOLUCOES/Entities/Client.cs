using MW_SOLUCOES.Enums;
using System.Numerics;

namespace MW_SOLUCOES.Entities;

public class Client : Person
{
    private int NumberOfOrders { get; set; }
    private ClientAccountStatus AccountStatus { get; set; }

    public Client(Guid id, string name, int age, string cpf, string phone, Address address, int numberOfOrders, ClientAccountStatus accountStatus) : base(id, name, age, cpf, phone, address)
    {
        NumberOfOrders = numberOfOrders;
        AccountStatus = accountStatus;
    }

        
}
