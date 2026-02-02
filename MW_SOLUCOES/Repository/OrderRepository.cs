using MW_SOLUCOES.Entities;
using MW_SOLUCOES.Enums;
using MW_SOLUCOES.Repository.Interfaces;
using MW_SOLUCOES.Data;

namespace MW_SOLUCOES.Repository;

public class OrderRepository : IOrderRepository
{
    public bool DeleteOrderByOrderCode(string orderCode)
    {
        var order = GetOrderByOrderCode(orderCode);
        if ( order == null)
        {
            return false;
        }
        else
        {
            OrderData.Orders.Remove(order);
            return true;
        }
    }

    public List<Order> GetAllClientOrdersByClientId(int id) => OrderData.Orders.Where(x => x.Client.Id == id).ToList();

    public List<Order> GetAllOrders() => OrderData.Orders;

    public List<Order> GetAllClosedOrders() => OrderData.Orders.Where(x => x.Status == OrderStatus.Closed).ToList();

    public List<Order> GetClosedOrdersByClientId(int id) => OrderData.Orders.Where(x => x.Client.Id == id && x.Status == OrderStatus.Closed).ToList();

    public List<Order> GetAllOpenOrders() => OrderData.Orders.Where(x => x.Status == OrderStatus.Open).ToList();

    public List<Order> GetOpenOrdersByClientId(int id) => OrderData.Orders.Where(x => x.Client.Id == id && x.Status == OrderStatus.Open).ToList();

    public Order? GetOrderByOrderCode(string orderCode) => OrderData.Orders.SingleOrDefault(x => x.OrderCode == orderCode);

    public List<Order> GetOrderByOrderDate(DateOnly date) => OrderData.Orders.Where(x => x.CreatedAt.HasValue && DateOnly.FromDateTime(x.CreatedAt.Value) == date).ToList();

    public List<Order> GetOrdersByServiceCategory(ServiceCategories category) => OrderData.Orders.Where(x => x.ServiceList.Any(y => y.ServiceChoosed.ServiceCategory == category)).ToList();

    public bool SaveOrder(Order order)
    {
        if (GetOrderByOrderCode(order.OrderCode) != null)
        {
            return false;
        }
        OrderData.Orders.Add(order);
        return true;
    }

    public bool UpdateOrderInfo(Order order)
    {
        var index = OrderData.Orders.FindIndex(x => x.OrderCode == order.OrderCode);
        if (index == -1)
        {
            return false;
        }
        OrderData.Orders[index] = order;
        return true;
    }
}
