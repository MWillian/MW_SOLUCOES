using MW_SOLUCOES.Exceptions;

namespace MW_SOLUCOES.Entities;

public class MaintenanceItem
{
    public MaintenanceService ServiceChoosed { get; private set; }
    public int Quantity { get; private set; }
    public MaintenanceItem(MaintenanceService serviceChoosed, int quantity)
    {
        ServiceChoosed = serviceChoosed;
        Quantity = quantity;
    }
    public void RaiseItemQuantity()
    {
        Quantity++;
    }
    public void DecreaseItemQuantity()
    {
        if (Quantity > 1)
        {
            Quantity--;
        }
        else
        {
            throw new NegocioException("Não é possível diminuir a quantidade do serviço. Tente removê-lo da ordem de serviço.");
        }
    }
}
