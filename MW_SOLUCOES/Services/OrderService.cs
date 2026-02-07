using MW_SOLUCOES.Entities;
using MW_SOLUCOES.Enums;
using MW_SOLUCOES.Exceptions;
using MW_SOLUCOES.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MW_SOLUCOES.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IMaintenanceRepository _maintenanceRepository;

    public OrderService(IOrderRepository orderRepository, IClientRepository clientRepository,IMaintenanceRepository maintenanceRepository)
    {
        _orderRepository = orderRepository;
        _clientRepository = clientRepository;
        _maintenanceRepository = maintenanceRepository;
    }

    public Order CreateOrder(int clientId, List<int> serviceIds, PaymentMethod method, string description)
    {
        var client = _clientRepository.GetClientById(clientId);
        if (client == null)
        {
            throw new NegocioException($"Cliente {clientId} não encontrado.");
        }

        if (client.AccountStatus == ClientAccountStatus.Blocked)
        {
            throw new NegocioException("Este cliente está bloqueado e não pode abrir novas ordens.");
        }

        var items = new List<MaintenanceItem>();

        foreach (var serviceId in serviceIds)
        {
            var service = _maintenanceRepository.GetById(serviceId);

            if (service == null)
                throw new NegocioException($"Serviço {serviceId} não encontrado.");

            if (service.ServiceActualStatus == ServiceStatus.Unavailable)
                throw new NegocioException($"O serviço '{service.Name}' está indisponível no momento.");

            items.Add(new MaintenanceItem(service, 1));
        }

        if (items.Count == 0)
        {
            throw new NegocioException("Não é possível criar um pedido sem serviços.");
        }

        var newOrder = new Order(
            Guid.NewGuid(),
            client,
            method,
            null, 
            items,
            description
        );

        client.RegisterNewOrder();
        _clientRepository.UpdateClient(client); 

        _orderRepository.SaveOrder(newOrder);

        return newOrder;
    }

    public void AddServiceToOrder(string orderCode, int serviceId)
    {
        var order = _orderRepository.GetOrderByOrderCode(orderCode);
        if (order == null)
            throw new NegocioException("Pedido não encontrado.");

        if (order.Status == OrderStatus.Closed)
            throw new NegocioException("Não é possível adicionar itens a um pedido fechado.");

        var service = _maintenanceRepository.GetById(serviceId);
        if (service == null)
            throw new NegocioException("Serviço não encontrado.");

        var newItem = new MaintenanceItem(service, 1);
        order.AddServiceToOrder(newItem);

        _orderRepository.UpdateOrderInfo(order);
    }

    public void CloseOrder(string orderCode)
    {
        var order = _orderRepository.GetOrderByOrderCode(orderCode);
        if (order == null) throw new NegocioException("Pedido não encontrado.");

        order.CloseOrder();

        _orderRepository.UpdateOrderInfo(order);
    }

    public Order ConsultOrder(string orderCode)
    {
        var order = _orderRepository.GetOrderByOrderCode(orderCode);
        if (order == null) throw new NegocioException("Pedido não encontrado.");
        return order;
    }

    public void RemoveServiceFromOrder(string orderCode, int serviceId)
    {
        var order = _orderRepository.GetOrderByOrderCode(orderCode);
        if (order == null) throw new NegocioException("Pedido não encontrado.");

        if (order.Status == OrderStatus.Closed)
            throw new NegocioException("Não é possível remover itens de um pedido fechado.");

        // Precisamos encontrar o item dentro da lista da ordem que corresponda ao ID do serviço
        var itemToRemove = order.ServiceList.FirstOrDefault(i => i.ServiceChoosed.Id == serviceId);

        if (itemToRemove == null)
        {
            throw new NegocioException("Este serviço não consta neste pedido.");
        }

        order.RemoveServiceFromOrder(itemToRemove);

        _orderRepository.UpdateOrderInfo(order);
    }

    public void UpdateDescription(string orderCode, string newDescription)
    {
        var order = _orderRepository.GetOrderByOrderCode(orderCode);
        if (order == null) throw new NegocioException("Pedido não encontrado.");

        if (order.Status == OrderStatus.Closed)
            throw new NegocioException("Não é possível alterar a descrição de um pedido fechado.");

        order.UpdateOrderDescription(newDescription);

        _orderRepository.UpdateOrderInfo(order);
    }
    public List<Order> ListClientOrders(int clientId)
    {
        return _orderRepository.GetAllClientOrdersByClientId(clientId);
    }
}