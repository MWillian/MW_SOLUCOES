using MW_SOLUCOES.Enums;

namespace MW_SOLUCOES.Entities;

public class MaintenanceService
{
    private Guid Id { get; set; }
    private int ServiceCode {  get; set; }
    private string Name { get; set; } = string.Empty;
    private string Description { get; set; } = string.Empty;
    private decimal? Price { get; set; }
    private ServiceStatus ServiceStatus { get; set; }
    private ServiceCategories ServiceCategories { get; set; }

    public MaintenanceService(Guid id, string name, string description, decimal? price, ServiceStatus serviceStatus, ServiceCategories serviceCategories, int serviceCode)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        ServiceStatus = serviceStatus;
        ServiceCategories = serviceCategories;
        ServiceCode = serviceCode;
    }
}
