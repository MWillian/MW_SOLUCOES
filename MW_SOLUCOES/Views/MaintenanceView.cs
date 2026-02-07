using System;
using MW_SOLUCOES.Services;

namespace MW_SOLUCOES.Views;

public class MaintenanceView
{
    private readonly MaintenanceService _service;

    public MaintenanceView(MaintenanceService service)
    {
        _service = service;
    }

    public void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("--- CATÁLOGO DE SERVIÇOS ---");
        Console.WriteLine("1. Listar Disponíveis");
        Console.WriteLine("2. Listar Todos");
        Console.Write("Opção: ");

        var op = Console.ReadLine();

        if (op == "1" || op == "2")
        {
            var lista = op == "1" ? _service.GetAvailableServices() : _service.GetAll();
            foreach (var s in lista)
            {
                Console.WriteLine($"ID: {s.Id} | {s.Name} | Preço: R$ {s.Price:F2} | Status: {s.ServiceActualStatus}");
            }
        }

        Console.WriteLine("\nPressione ENTER para voltar...");
        Console.ReadLine();
    }
}