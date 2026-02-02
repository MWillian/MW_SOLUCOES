using System;
using System.Collections.Generic;
using System.Linq;
using MW_SOLUCOES.Data;
using MW_SOLUCOES.Entities;
using MW_SOLUCOES.Enums;
using MW_SOLUCOES.Repository.Interfaces;

namespace MW_SOLUCOES.Repository;

public class MaintenanceRepository : IMaintenanceRepository
{
    public List<ServiceCatalog> GetAll()
    {
        return MaintenanceData.Services;
    }

    public ServiceCatalog? GetById(int id)
    {
        return MaintenanceData.Services.FirstOrDefault(s => s.Id == id);
    }

    public List<ServiceCatalog> GetAvailableServices()
    {
        return MaintenanceData.Services.Where(s => s.ServiceActualStatus == ServiceStatus.Available).ToList();
    }

    public List<ServiceCatalog> GetServicesByCategory(ServiceCategories category)
    {
        return MaintenanceData.Services.Where(s => s.ServiceCategory == category).ToList();
    }

    public List<ServiceCatalog> SearchByName(string name)
    {
        return MaintenanceData.Services.Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<ServiceCatalog> GetServicesByMaxPrice(decimal maxPrice)
    {
        return MaintenanceData.Services.Where(s => s.Price <= maxPrice).OrderBy(s => s.Price).ToList();
    }

    public bool Save(ServiceCatalog service)
    {
        if (MaintenanceData.Services.Any(s => s.Name.Equals(service.Name, StringComparison.OrdinalIgnoreCase)))
        {
            return false;
        }
        MaintenanceData.Services.Add(service);
        return true;
    }

    public bool Update(ServiceCatalog service)
    {
        var index = MaintenanceData.Services.FindIndex(s => s.Id == service.Id);
        if (index == -1)
        {
            return false;
        }
        MaintenanceData.Services[index] = service;
        return true;
    }

    public bool DeleteById(int id)
    {
        var service = GetById(id);
        if (service != null)
        {
            MaintenanceData.Services.Remove(service);
            return true;
        }
        return false;
    }
}