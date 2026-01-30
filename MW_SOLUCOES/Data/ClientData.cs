using System;
using System.Collections.Generic;
using MW_SOLUCOES.Entities;
using MW_SOLUCOES.Enums;

namespace MW_SOLUCOES.Data;

public static class ClientData
{
    public static List<Client> Clients { get; private set; } = new List<Client>();

    static ClientData()
    {
        Seed();
    }

    private static void Seed()
    {
        try
        {
            var addr1 = new Address("Av. Paulista", "1000", "Bela Vista", "São Paulo", "SP", "01310-100");
            var addr2 = new Address("Rua das Palmeiras", "50", "Centro", "Rio de Janeiro", "RJ", "20000-000");
            var addr3 = new Address("Rua Bahia", "300", "Savassi", "Belo Horizonte", "MG", "30110-010");
            var addr4 = new Address("Av. Bento Gonçalves", "1500", "Partenon", "Porto Alegre", "RS", "90650-002");
            var addr5 = new Address("Rua das Flores", "88", "Centro", "Curitiba", "PR", "80010-000");
            var addr6 = new Address("Av. Boa Viagem", "2500", "Boa Viagem", "Recife", "PE", "51020-000");

            Clients.Add(new Client(
                Guid.NewGuid(),
                new PersonName("Marcos", "Oliveira"),
                35,
                "12345678909",
                "5511999998888",
                addr1,
                "marcos@email.com",
                0,
                ClientAccountStatus.Active
            ));

            Clients.Add(new Client(
                Guid.NewGuid(),
                new PersonName("Ana", "Beatriz"),
                28,
                "11144477735",
                "5521888887777",
                addr2,
                "ana.b@email.com",
                2,
                ClientAccountStatus.Active
            ));

            Clients.Add(new Client(
                Guid.NewGuid(),
                new PersonName("Ricardo", "Santos"),
                42,
                "98765432100",
                "5531977776666",
                addr3,
                "ricardo.santos@prov.com",
                1,
                ClientAccountStatus.Active
            ));

            Clients.Add(new Client(
                Guid.NewGuid(),
                new PersonName("Juliana", "Lima"),
                31,
                "55544433380",
                "5551966665555",
                addr4,
                "ju.lima@teste.com.br",
                5,
                ClientAccountStatus.Active
            ));

            Clients.Add(new Client(
                Guid.NewGuid(),
                new PersonName("Carlos", "Ferreira"),
                55,
                "33322211169",
                "5541955554444",
                addr5,
                "carlos.f@oficina.com",
                0,
                ClientAccountStatus.Blocked
            ));

            Clients.Add(new Client(
                Guid.NewGuid(),
                new PersonName("Beatriz", "Souza"),
                24,
                "44477788827",
                "5581944443333",
                addr6,
                "bia.souza@email.net",
                3,
                ClientAccountStatus.Active
            ));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro crítico ao inicializar banco de Clientes: {ex.Message}");
        }
    }
}