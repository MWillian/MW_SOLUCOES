using System;
using Microsoft.Extensions.DependencyInjection;
using MW_SOLUCOES.Repository;
using MW_SOLUCOES.Repository.Interfaces;
using MW_SOLUCOES.Services;
using MW_SOLUCOES.Exceptions;
using MW_SOLUCOES.Entities;
using MW_SOLUCOES.Enums;
using MW_SOLUCOES.Views; 

namespace MW_SOLUCOES;

public class Program
{
    public static void Main(string[] args)
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        var serviceProvider = services.BuildServiceProvider();

        var clientView = serviceProvider.GetRequiredService<ClientView>();
        var maintenanceView = serviceProvider.GetRequiredService<MaintenanceView>();
        var orderView = serviceProvider.GetRequiredService<OrderView>();

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("   SISTEMA MW SOLUÇÕES - OFICINA TÉCNICA");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Gerenciar Clientes");
            Console.WriteLine("2. Catálogo de Serviços");
            Console.WriteLine("3. Gerenciar Ordens de Serviço");
            Console.WriteLine("0. Sair");
            Console.Write("\nEscolha uma opção: ");

            var input = Console.ReadLine();

            try
            {
                switch (input)
                {
                    case "1":
                        clientView.ShowMenu();
                        break;
                    case "2":
                        maintenanceView.ShowMenu();
                        break;
                    case "3":
                        orderView.ShowMenu();
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("Encerrando o sistema...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[ERRO DE SISTEMA]: {ex.Message}");
                Console.ResetColor();
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();
            }
        }
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IClientRepository, ClientRepository>();
        services.AddSingleton<IOrderRepository, OrderRepository>();
        services.AddSingleton<IMaintenanceRepository, MaintenanceRepository>();

        services.AddTransient<ClientService>();
        services.AddTransient<MaintenanceService>();
        services.AddTransient<OrderService>();

        services.AddTransient<ClientView>();
        services.AddTransient<MaintenanceView>();
        services.AddTransient<OrderView>();
    }
}