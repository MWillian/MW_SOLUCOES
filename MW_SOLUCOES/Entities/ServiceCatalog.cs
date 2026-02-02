namespace MW_SOLUCOES.Entities;

using MW_SOLUCOES.Enums;
using MW_SOLUCOES.Exceptions;

public class ServiceCatalog
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public ServiceStatus ServiceActualStatus { get; private set; } 
    public ServiceCategories ServiceCategory { get; private set; }

    public ServiceCatalog(int id, string name, string description, decimal price, ServiceCategories serviceCategories, ServiceStatus serviceStatus = ServiceStatus.Unavailable)
    {
        Id = id;
        UpdateServiceName(name);
        UpdateServiceDescription(description);
        UpdateServicePrice(price);
        ServiceActualStatus = serviceStatus;
        ServiceCategory = serviceCategories;
    }

    public void UpdateServiceCategory(ServiceCategories newServiceCaterory)
    {
        ServiceCategory = newServiceCaterory;
    }

    public void ChangeServiceStatus()
    {
        if(ServiceActualStatus == ServiceStatus.Available)
        {
            ServiceActualStatus = ServiceStatus.Unavailable;
        }
        else
        {
            ServiceActualStatus = ServiceStatus.Available;
        }
    }

    public void UpdateServicePrice(decimal newServicePrice)
    {
        if (newServicePrice < 0)
        {
            throw new NegocioException("O preço do serviço não pode ser menor do que 0.");
        }
        Price = newServicePrice;
    }

    public void UpdateServiceDescription(string newServiceDescription)
    {
        if (string.IsNullOrWhiteSpace(newServiceDescription))
        {
            throw new NegocioException("Descrição do serviço vazia.");
        }
        Description = newServiceDescription;
    }
    public void UpdateServiceName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new NegocioException("Nome do serviço vazio.");
        }
        Name = name;
    }
}
