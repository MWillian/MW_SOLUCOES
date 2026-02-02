using MW_SOLUCOES.Enums;
using System.Numerics;

namespace MW_SOLUCOES.Entities;

public class Client : Person
{
    public int NumberOfOrders { get; private set; }
    public ClientAccountStatus AccountStatus { get; private set; }
    
    public Client(int id, PersonName name, int age, string cpf, string phone, Address address, string email,int numberOfOrders = 0,ClientAccountStatus accountStatus = ClientAccountStatus.Active) : base(id, name, age, cpf, phone, address, email)
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
