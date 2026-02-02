using MW_SOLUCOES.Entities;
using MW_SOLUCOES.Enums;
using System;
using System.Collections.Generic;

namespace MW_SOLUCOES.Repository.Interfaces;

public interface IMaintenanceRepository
{
    bool Save(ServiceCatalog service);
    bool Update(ServiceCatalog service);
    bool DeleteById(int id);
    List<ServiceCatalog> GetAll();
    ServiceCatalog? GetById(int id);
    List<ServiceCatalog> GetAvailableServices();
    List<ServiceCatalog> GetServicesByCategory(ServiceCategories category);
    List<ServiceCatalog> SearchByName(string name);
    List<ServiceCatalog> GetServicesByMaxPrice(decimal maxPrice);
}