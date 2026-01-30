using MW_SOLUCOES.Enums;
using MW_SOLUCOES.Exceptions;
using MW_SOLUCOES.Helpers;

namespace MW_SOLUCOES.Entities;

public class Order
{
    public Guid Id {  get; private set; }
    public Client Client { get; private set; }
    public string OrderCode {  get; private set; } = string.Empty;
    public PaymentMethod PaymentMethod { get; private set; }
    public List<MaintenanceItem> ServiceList { get; private set; }
    public OrderStatus Status { get; private set; }
    public DateTime? CreatedAt { get; private set; }
    public DateTime? LastUpdatedAt { get; private set; }
    public DateTime? FinishedAt { get; private set; }
    public List<string> Descriptions { get; private set; } = new List<string>();
    public Order(Guid id, Client client, PaymentMethod paymentMethod, string orderCode, List<MaintenanceItem> serviceList ,string description, DateTime? createdAt = null, DateTime? lastUpdatedAt = null, DateTime? finishedAt = null, OrderStatus orderStatus = OrderStatus.Open)
    {
        Id = id;
        Client = client;
        PaymentMethod = paymentMethod;
        OrderCode = string.IsNullOrWhiteSpace(orderCode) ? OrderCodeGeneratorHelper.GenerateCode() : orderCode;
        ServiceList = serviceList;
        UpdateOrderDescription(description);
        CreatedAt = createdAt ?? DateTime.Now;
        LastUpdatedAt = lastUpdatedAt ?? CreatedAt;
        FinishedAt = finishedAt ?? finishedAt;
        Status = orderStatus;
    }
    public void UpdateOrderDescription(string newDescription)
    {
        if (string.IsNullOrWhiteSpace(newDescription))
        {
            throw new NegocioException("A descrição não por ser vazia");
        }
        LastUpdatedAt = DateTime.Now;
        Descriptions.Add(newDescription);
    }

    public void CloseOrder()
    {
        Status = OrderStatus.Closed;
        FinishedAt = DateTime.Now;
    }
    
    public void UpdatePaymentMethod(PaymentMethod newPaymentMethod)
    {
        PaymentMethod = newPaymentMethod;
    }

    public void AddServiceToOrder(MaintenanceItem service)
    {
        if (ServiceList.Contains(service))
        {
            ServiceList.First(x => x == service).RaiseItemQuantity();
        }
        else
        {
            ServiceList.Add(service);
        }
    }

    public void ReduceServiceAmount(MaintenanceItem maintenanceItem)
    {
        if (ServiceList.Contains(maintenanceItem))
        {
            ServiceList.First(x => x == maintenanceItem).DecreaseItemQuantity();
        }
        else
        {
            throw new NegocioException("O serviço solicitado para diminuir a quantidade não está na ordem de serviço.");
        }
    }

    public void RemoveServiceFromOrder(MaintenanceItem service)
    {
        if (ServiceList.Contains(service))
        {
            ServiceList.Remove(service);
        }
        else
        {
            throw new NegocioException("O serviço solicitado para remoção não está na ordem de serviço.");
        }
    }

    public decimal CalculateTotal()
    {
        var total = 0m;
        foreach (var item in ServiceList)
        {
            total += item.Quantity * item.ServiceChoosed.Price;
        }
        return total;
    }
}
