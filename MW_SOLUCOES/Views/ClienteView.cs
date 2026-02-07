using System;
using MW_SOLUCOES.Services;

namespace MW_SOLUCOES.Views;

public class ClientView
{
    private readonly ClientService _service;

    public ClientView(ClientService service)
    {
        _service = service;
    }

    public void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("--- GESTÃO DE CLIENTES ---");
        Console.WriteLine("1. Listar Todos");
        Console.WriteLine("2. Buscar por ID");
        Console.WriteLine("3. Buscar por CPF");
        Console.Write("Opção: ");

        var op = Console.ReadLine();

        try
        {
            if (op == "1") ListAllClients();
            else if (op == "2") GetClientById();
            else if (op == "3") GetClientByCpf();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }

        Console.WriteLine("\nPressione ENTER para voltar...");
        Console.ReadLine();
    }

    private void ListAllClients()
    {
        var lista = _service.ListAll();
        foreach (var c in lista)
        {
            Console.WriteLine($"ID: {c.Id} | Nome: {c.Name.FirstName} {c.Name.LastName} | CPF: {c.CPF} | Status: {c.AccountStatus}");
        }
    }

    private void GetClientById()
    {
        Console.Write("Digite o ID: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var c = _service.GetClientById(id);
            Console.WriteLine($"Cliente: {c.Name.FirstName} - Email: {c.Email}");
        }
    }

    private void GetClientByCpf()
    {
        Console.Write("Digite o CPF: ");
        var cpf = Console.ReadLine();
        var c = _service.GetByCPF(cpf);
        Console.WriteLine($"Cliente: {c.Name.FirstName} - ID: {c.Id}");
    }
}