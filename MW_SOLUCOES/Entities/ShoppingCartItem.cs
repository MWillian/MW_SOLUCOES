namespace MW_SOLUCOES.Entities;

public class ShoppingCartItem
{
    private Product Product { get; set; }
    private decimal UnitCost { get; set; }    
    private int Quantity { get; set; }

    public ShoppingCartItem(Product product, decimal unitCost, int quantity)
    {
        Product = product;
        UnitCost = unitCost;
        Quantity = quantity;
    }
}
