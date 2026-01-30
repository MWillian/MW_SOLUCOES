namespace MW_SOLUCOES.Entities;

using MW_SOLUCOES.Enums;
using MW_SOLUCOES.Exceptions;
using MW_SOLUCOES.Helpers;

public class MaintenanceService
{
    public Guid Id { get; private set; }
    public Client Client { get; private set; }
    public string ServiceCode {  get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public ServiceStatus ServiceActualStatus { get; private set; } 
    public ServiceCategories ServiceCategory { get; private set; }
    public DateTime? CreatedAt { get; private set; }
    public DateTime? LastUpdatedAt { get; private set; }
    public DateTime? FinishedAt { get; private set; }
    public MaintenanceService(Guid id, string name, string description, decimal price, ServiceCategories serviceCategories, Client client, ServiceStatus serviceStatus = ServiceStatus.Unavailable, string? serviceCode = null, DateTime? createdAt = null, DateTime? lastUpdatedAt = null, DateTime? finishedAt = null)
    {
        Id = id;
        UpdateServiceName(name);
        UpdateServiceDescription(description);
        UpdateServicePrice(price);
        ServiceActualStatus = serviceStatus;
        ServiceCategory = serviceCategories;
        Client = client;
        ServiceCode = string.IsNullOrWhiteSpace(serviceCode) ? ServiceCodeGeneratorHelper.GenerateCode() : serviceCode;
        CreatedAt = createdAt ?? DateTime.Now;
        LastUpdatedAt = lastUpdatedAt ?? CreatedAt;
        FinishedAt = finishedAt ?? finishedAt;
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
