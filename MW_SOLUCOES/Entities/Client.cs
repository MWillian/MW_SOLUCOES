using MW_SOLUCOES.Enums;
using System.Numerics;

namespace MW_SOLUCOES.Entities;

public class Client : Person
{
    public int NumberOfOrders { get; private set; }
    public ClientAccountStatus AccountStatus { get; private set; }
    public Client(Guid id, ClientName name, int age, string cpf, string phone, Address address, ClientAccountStatus accountStatus, int numberOfOrders = 0) : base(id, name, age, cpf, phone, address)
    {
        NumberOfOrders = numberOfOrders;
        AccountStatus = accountStatus;
    }
    public void RegisterNewOrder()
    {
        NumberOfOrders++;
    }

    public void UpdateAccountStatus(ClientAccountStatus accountStatus)
    {
        AccountStatus = accountStatus;
    }
}
