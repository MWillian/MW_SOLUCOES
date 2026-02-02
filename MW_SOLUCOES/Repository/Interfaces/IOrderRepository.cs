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
    public void SaveOrder(Order order);
    public void DeleteOrder(Order order);
    public List<Order> GetAllClientOrdersByClientId(int id);
    public List<Order> GetOpenOrdersByClientId(int id);
    public List<Order> GetClosedOrdersByClientId(int id);
    public List<Order> GetAllOrders();
    public Order GetOrderByOrderCode(string orderCode);
    public List<Order> GetOrderByOrderDate(DateOnly date);
    public List<Order> GetOpenOrders();
    public List<Order> GetClosedOrders();
    public List<Order> GetOrdersByServiceCategory(ServiceCategories category);
    public void UpdateOrderInfo(int id, string field, string newData);
}
