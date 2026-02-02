using MW_SOLUCOES.Entities;
using MW_SOLUCOES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW_SOLUCOES.Repository.Interfaces;
internal interface IOrderRepository
{
    public bool SaveOrder(Order order);
    public bool DeleteOrderByOrderCode(string orderCode);
    public List<Order> GetAllClientOrdersByClientId(int id);
    public List<Order> GetOpenOrdersByClientId(int id);
    public List<Order> GetClosedOrdersByClientId(int id);
    public List<Order> GetAllOrders();
    public Order? GetOrderByOrderCode(string orderCode);
    public List<Order> GetOrderByOrderDate(DateOnly date);
    public List<Order> GetAllOpenOrders();
    public List<Order> GetAllClosedOrders();
    public List<Order> GetOrdersByServiceCategory(ServiceCategories category);
    public bool UpdateOrderInfo(Order order);
}
