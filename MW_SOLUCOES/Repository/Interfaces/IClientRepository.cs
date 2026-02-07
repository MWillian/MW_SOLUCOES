using MW_SOLUCOES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW_SOLUCOES.Repository.Interfaces;
public interface IClientRepository
{
    public Client? SaveClient(Client client);
    public bool DeleteClientById(int id);
    public Client? GetClientById(int id);
    public Client? GetClientByCPF(string cpf);
    public Client? GetClientByName(string name);
    public List<Client> GetActiveClients();
    public List<Client> GetBlockedClients();
    public List<Client> GetAllClients();
    public bool UpdateClient(Client client);
}
