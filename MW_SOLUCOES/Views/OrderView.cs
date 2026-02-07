using System;
using System.Collections.Generic;
using MW_SOLUCOES.Services;
using MW_SOLUCOES.Enums;

namespace MW_SOLUCOES.Views;

public class OrderView
{
    private readonly OrderService _orderService;
    private readonly MaintenanceService _maintenanceService;

    public OrderView(OrderService orderService, MaintenanceService maintenanceService)
    {
        _orderService = orderService;
        _maintenanceService = maintenanceService;
    }

    public void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("--- GESTÃO DE ORDENS ---");
        Console.WriteLine("1. Criar Nova Ordem");
        Console.WriteLine("2. Consultar Ordem por Código");
        Console.Write("Opção: ");

        var op = Console.ReadLine();

        try
        {
            if (op == "1") CreateOrder();
            else if (op == "2") ConsultOrder();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }

        Console.WriteLine("\nPressione ENTER para voltar...");
        Console.ReadLine();
    }

    private void CreateOrder()
    {
        Console.Write("ID do Cliente: ");
        int clientId = int.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine("Serviços Disponíveis (Copie o ID):");
        foreach (var s in _maintenanceService.GetAvailableServices())
        {
            Console.WriteLine($"{s.Id} - {s.Name}");
        }

        Console.Write("Digite os IDs dos serviços separados por vírgula: ");
        string[] idsInput = (Console.ReadLine() ?? "").Split(',');

        List<int> serviceIds = new List<int>();
        foreach (var idStr in idsInput)
        {
            if (int.TryParse(idStr.Trim(), out int id)) serviceIds.Add(id);
        }

        Console.Write("Descrição do Problema: ");
        string desc = Console.ReadLine() ?? "";

         var order = _orderService.CreateOrder(clientId, serviceIds, PaymentMethod.Cash, desc);
        Console.WriteLine($"Ordem criada com sucesso!");
    }

    private void ConsultOrder()
    {
        Console.Write("Código da Ordem: ");
        var code = Console.ReadLine();
        var order = _orderService.ConsultOrder(code);

        Console.WriteLine($"\nPEDIDO: {order.OrderCode}");
        Console.WriteLine($"Cliente: {order.Client.Name.FirstName}");
        Console.WriteLine($"Status: {order.Status}");
        Console.WriteLine($"Total: R$ {order.CalculateTotal():F2}");
        Console.WriteLine("Itens:");
        foreach (var item in order.ServiceList)
        {
            Console.WriteLine($"- {item.ServiceChoosed.Name} (Qtd: {item.Quantity})");
        }
    }
}