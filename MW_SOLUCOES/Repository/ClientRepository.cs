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

    public List<Client> GetActiveClients()
    {
        return ClientData.Clients.Where(x => x.AccountStatus == ClientAccountStatus.Active).ToList();
    }

    public List<Client> GetAllClients()
    {
        return ClientData.Clients;
    }

    public List<Client> GetBlockedClients()
    {
        return ClientData.Clients.Where(x => x.AccountStatus == ClientAccountStatus.Blocked).ToList();
    }

    public Client? GetClientByCPF(string cpf)
    {
        return ClientData.Clients.SingleOrDefault(x => x.CPF == cpf);
    }

    public Client? GetClientById(int id)
    {
        return ClientData.Clients.SingleOrDefault(x => x.Id == id);
    }

    public Client? GetClientByName(string name)
    {
        return ClientData.Clients.SingleOrDefault(x => $"{x.Name.FirstName} {x.Name.LastName}" == name);
    }

    public bool SaveClient(Client client)
    {
        if (ClientData.Clients.Any(x => x.CPF == client.CPF))        {
            return false;
        }
        else
        {
            //implementar
            return true;
        }
    }

    public bool UpdateClient(Client client)
    {
        throw new NotImplementedException();
    }
}
