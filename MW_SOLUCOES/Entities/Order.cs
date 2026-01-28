using MW_SOLUCOES.Enums;

namespace MW_SOLUCOES.Entities;

public class Order
{
    private Guid Id {  get; set; }
    private int OrderCode {  get; set; }
    private Client Client { get; set; }
    private ShoppingCart ShoppingCart {  get; set; }
    private PaymentMethod PaymentMethod { get; set; }
    public Order(Guid id, Client client, ShoppingCart shoppingCart, PaymentMethod paymentMethod, int orderCode)
    {
        Id = id;
        Client = client;
        ShoppingCart = shoppingCart;
        PaymentMethod = paymentMethod;
        OrderCode = orderCode;
    }
}
