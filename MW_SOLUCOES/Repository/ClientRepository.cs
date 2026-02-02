namespace MW_SOLUCOES.Repository;

using MW_SOLUCOES.Data;
using MW_SOLUCOES.Entities;
using MW_SOLUCOES.Enums;
using MW_SOLUCOES.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

public class ClientRepository : IClientRepository
{
    public bool DeleteClientById(int id)
    {
        var client = GetClientById(id);
        if (client != null)
        {
            ClientData.Clients.Remove(client);
            return true;
        }
        else
        {
            return false;
        }
    }
        
    public List<Client> GetActiveClients() => ClientData.Clients.Where(x => x.AccountStatus == ClientAccountStatus.Active).ToList();
        
    public List<Client> GetAllClients() => ClientData.Clients;

    public List<Client> GetBlockedClients() => ClientData.Clients.Where(x => x.AccountStatus == ClientAccountStatus.Blocked).ToList();

    public Client? GetClientByCPF(string cpf) => ClientData.Clients.SingleOrDefault(x => x.CPF == cpf);
    
    public Client? GetClientById(int id) => ClientData.Clients.SingleOrDefault(x => x.Id == id);

    public Client? GetClientByName(string name) => ClientData.Clients.SingleOrDefault(x => $"{x.Name.FirstName} {x.Name.LastName}" == name);

    public bool SaveClient(Client client)
    {
        if (GetClientByCPF(client.CPF) == null)
        {
            client.AssignId(ClientData.GetNextId());
            ClientData.Clients.Add(client);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool UpdateClient(Client client)
    {
        Client actualClient = GetClientById(client.Id);
        if ( actualClient == null)
        {
            return false;
        }
        else
        {
            actualClient.UpdateCpf(client.CPF);
            actualClient.UpdateEmail(client.Email);
            actualClient.UpdatePhone(client.Phone);
            actualClient.UpdateAccountStatus(client.AccountStatus);
            actualClient.UpdateName(client.Name.FirstName,client.Name.LastName);
            actualClient.UpdateAddress(client.Address);
            actualClient.UpdateAge(client.Age);
            return true;
        }
    }
}
