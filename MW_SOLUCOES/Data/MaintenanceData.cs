using MW_SOLUCOES.Entities;
using MW_SOLUCOES.Enums;

namespace MW_SOLUCOES.Data;

public static class MaintenanceData
{
    public static List<MaintenanceService> Services { get; private set; } = new List<MaintenanceService>();
    private static int _nextInt = 6;

    static MaintenanceData()
    {
        Seed();
    }

    private static void Seed()
    {
        try
        {
            Services.Add(new MaintenanceService(
                1,
                "Formatação Completa",
                "Reinstalação do sistema operacional, backup de dados e instalação de drivers.",
                150.00m,
                ServiceCategories.CorrectiveMaintence,
                ServiceStatus.Available
            ));

            Services.Add(new MaintenanceService(
                2,
                "Montagem de Computador Standard",
                "Montagem de PC para escritório ou estudo com organização básica de cabos.",
                200.00m,
                ServiceCategories.PreventiveMaintence,
                ServiceStatus.Available
            ));

            Services.Add(new MaintenanceService(
                3,
                "Montagem de Computador Gamer/High-End",
                "Montagem especializada com cable management avançado e instalação de sistemas de refrigeração complexos.",
                450.00m,
                ServiceCategories.PreventiveMaintence,
                ServiceStatus.Available
            ));

            Services.Add(new MaintenanceService(
                4,
                "Limpeza Preventiva Interna",
                "Remoção de poeira, lubrificação de coolers e aplicação de nova pasta térmica de alta performance.",
                120.00m,
                ServiceCategories.PreventiveMaintence,
                ServiceStatus.Available
            ));

            Services.Add(new MaintenanceService(
                5,
                "Substituição de Periféricos Internos",
                "Troca de memórias RAM, SSDs, HDs ou placas de rede.",
                80.00m,
                ServiceCategories.CorrectiveMaintence,
                ServiceStatus.Available
            ));

            Services.Add(new MaintenanceService(
                6,
                "Substituição de Hardware Principal",
                "Troca de Placa-mãe, Processador ou Fonte de Alimentação.",
                250.00m,
                ServiceCategories.CorrectiveMaintence,
                ServiceStatus.Available
            ));

            Services.Add(new MaintenanceService(
                7,
                "Diagnóstico Técnico Avançado",
                "Análise completa de hardware e software para identificação de defeitos intermitentes.",
                90.00m,
                ServiceCategories.CorrectiveMaintence,
                ServiceStatus.Available
            ));

            Services.Add(new MaintenanceService(
                8,
                "Recuperação de Dados em Disco Rígido",
                "Serviço especializado de recuperação de arquivos em discos com falha física.",
                600.00m,
                ServiceCategories.CorrectiveMaintence,
                ServiceStatus.Unavailable
            ));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao inicializar catálogo de serviços: {ex.Message}");
        }
    }
    public static void IncrementId()
    {
        _nextInt++;
    }
}