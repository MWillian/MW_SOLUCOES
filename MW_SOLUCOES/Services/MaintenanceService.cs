using MW_SOLUCOES.Entities;
using MW_SOLUCOES.Enums;
using MW_SOLUCOES.Exceptions;
using MW_SOLUCOES.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MW_SOLUCOES.Services;

public class MaintenanceService
{
    private readonly IMaintenanceRepository _maintenanceRepository;

    public MaintenanceService(IMaintenanceRepository maintenanceRepository)
    {
        _maintenanceRepository = maintenanceRepository;
    }

    public void RegisterNewService(ServiceCatalog service)
    {
        if (service.Price < 0)
        {
            throw new NegocioException("O preço do serviço não pode ser negativo.");
        }

        bool success = _maintenanceRepository.Save(service);

        if (!success)
        {
            throw new NegocioException($"Já existe um serviço cadastrado com o nome '{service.Name}'.");
        }
    }

    public ServiceCatalog GetById(int id)
    {
        var service = _maintenanceRepository.GetById(id);

        if (service == null)
        {
            throw new NegocioException($"Serviço de manutenção com ID {id} não encontrado.");
        }

        return service;
    }

    public List<ServiceCatalog> GetAll()
    {
        return _maintenanceRepository.GetAll();
    }

    public List<ServiceCatalog> GetAvailableServices()
    {
        return _maintenanceRepository.GetAvailableServices();
    }

    public List<ServiceCatalog> GetByCategory(ServiceCategories category)
    {
        var services = _maintenanceRepository.GetServicesByCategory(category);
        return services;
    }

    public List<ServiceCatalog> SearchByName(string term)
    {
        if (string.IsNullOrWhiteSpace(term))
            throw new NegocioException("O termo de busca não pode ser vazio.");

        return _maintenanceRepository.SearchByName(term);
    }

    public void UpdateServiceData(ServiceCatalog updatedService)
    {
        var existingService = _maintenanceRepository.GetById(updatedService.Id);
        if (existingService == null)
        {
            throw new NegocioException("Tentativa de atualizar um serviço que não existe.");
        }

        if (!existingService.Name.Equals(updatedService.Name, StringComparison.OrdinalIgnoreCase))
        {
            var servicesWithSameName = _maintenanceRepository.SearchByName(updatedService.Name);

            if (servicesWithSameName.Any(s => s.Id != updatedService.Id && s.Name.Equals(updatedService.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new NegocioException($"Já existe outro serviço com o nome '{updatedService.Name}'.");
            }
        }

        bool success = _maintenanceRepository.Update(updatedService);

        if (!success)
        {
            throw new NegocioException("Falha ao atualizar o serviço.");
        }
    }

    public void ToggleAvailability(int id)
    {
        var service = GetById(id);

        service.ChangeServiceStatus();

        _maintenanceRepository.Update(service);
    }

    public void UpdatePrice(int id, decimal newPrice)
    {
        var service = GetById(id);

        try
        {
            service.UpdateServicePrice(newPrice);
        }
        catch (NegocioException ex)
        {
            throw ex;
        }

        _maintenanceRepository.Update(service);
    }


    public void RemoveService(int id)
    {
        var service = GetById(id); 

        bool success = _maintenanceRepository.DeleteById(id);

        if (!success)
        {
            throw new NegocioException("Não foi possível remover o serviço.");
        }
    }
}