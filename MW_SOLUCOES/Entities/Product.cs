using MW_SOLUCOES.Enums;
using MW_SOLUCOES.Exceptions;
using System.Diagnostics;

namespace MW_SOLUCOES.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public ProductCategories Category { get; private set; }
    public ProductStatus Status { get; private set; }
    public bool IsPromotion {  get; private set; }
    public decimal PromotionPercentage { get; private set; }
    public ProductPreservation Preservation { get; private set; }

    public Product(Guid id, string name, string description, decimal price, int stock, ProductCategories category, ProductStatus status, bool isPromotion, ProductPreservation preservation, decimal promotionPercentage)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Category = category;
        Status = status;
        IsPromotion = isPromotion;
        Preservation = preservation;
        PromotionPercentage = promotionPercentage;
    }

    public void ChangeProductCategory(ProductCategories category)
    {
        Category = category;
    }
    public void ChangeProductPreservation(ProductPreservation preservation)
    {
        Preservation = preservation;
    }
    public void ChangePromotion()
    {
        IsPromotion = !IsPromotion;
    }
    public void ChangePromotionPercentage(decimal percentage)
    {
        if(percentage < 0 || percentage > 1)
        {
            throw new NegocioException("A porcentagem do desconto deve estar entre 0 e 100%.");
        }
        PromotionPercentage = percentage;
    }
    public decimal PriceWithDiscountPercentage()
    {
        if(IsPromotion == false)
        {
            throw new NegocioException("O produto não está na promoção.");
        }
        decimal totalPrice = Price - (Price * PromotionPercentage);
        return totalPrice;
    }
    public void ChangeStatus()
    {
        if (Status == ProductStatus.Available)
        {
            Status = ProductStatus.Unavailable;
        }
        else
        {
            Status = ProductStatus.Available;
        }
    }
}
