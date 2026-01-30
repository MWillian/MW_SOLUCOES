namespace MW_SOLUCOES.Data;
using Entities;
using MW_SOLUCOES.Enums;

public static class OrderData
{
    public static List<Order> Orders { get; private set; } = new List<Order>();

    static OrderData()
    {
        Seed();
    }

    private static void Seed()
    {
        try{
            if (!ClientData.Clients.Any() || !MaintenanceData.Services.Any())
            {
                return;
            }
            var cliente1 = ClientData.Clients.First(c => c.Name.FirstName == "Marcos");
            var servicoFormatar = MaintenanceData.Services.First(s => s.Name.Contains("Formatação"));

            var itens1 = new List<MaintenanceItem>
            {
                new MaintenanceItem(servicoFormatar, 1)
            };

            var order1 = new Order(
                Guid.NewGuid(),
                cliente1,
                PaymentMethod.CreditCard,
                null,
                itens1
            );

            var cliente2 = ClientData.Clients.First(c => c.Name.FirstName == "Juliana");
            var servicoMontagem = MaintenanceData.Services.First(s => s.Name.Contains("Gamer"));
            var servicoLimpeza = MaintenanceData.Services.First(s => s.Name.Contains("Limpeza"));

            var itens2 = new List<MaintenanceItem>
            {
                new MaintenanceItem(servicoMontagem, 1),
                new MaintenanceItem(servicoLimpeza, 1)
            };

            var order2 = new Order(
                Guid.NewGuid(),
                cliente2,
                PaymentMethod.Pix,
                null,
                itens2
            );

            var cliente3 = ClientData.Clients.First(c => c.Name.FirstName == "Ricardo");
            var servicoDiagnostico = MaintenanceData.Services.First(s => s.Name.Contains("Diagnóstico"));

            var itens3 = new List<MaintenanceItem> { new MaintenanceItem(servicoDiagnostico, 1) };

            DateTime dataAntiga = DateTime.Now.AddMonths(-1);

            var order3 = new Order(
                Guid.NewGuid(),
                cliente3,
                PaymentMethod.Cash,
                "OS-20230901-001", 
                itens3,
                dataAntiga,
                dataAntiga
            );

            Orders.AddRange(new List<Order> { order1, order2, order3 });
        }catch(Exception ex)
        {
            Console.WriteLine($"Erro ao gerar banco de Pedidos: {ex.Message}");
        }
    }
}
