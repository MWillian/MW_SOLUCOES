namespace MW_SOLUCOES.Entities;

public class ShoppingCart
{
    private Guid Id {  get; set; }
    private int AmmountOfDistinctProducts { get; set; }
    private List<ShoppingCartItem> Products { get; set; }
    public ShoppingCart(Guid id, int ammountOfProducts, List<ShoppingCartItem> products)
    {
        Id = id;
        AmmountOfDistinctProducts = ammountOfProducts;
        Products = products;
    }
}
