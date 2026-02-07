# MW Soluções - Sistema de Gestão de Oficina Técnica

Este projeto é uma aplicação de console desenvolvida em C# / .NET que simula o fluxo operacional de uma oficina de manutenção de computadores. O objetivo principal foi aplicar conceitos avançados de Programação Orientada a Objetos (POO) e Arquitetura de Software, simulando um ambiente real de desenvolvimento.

## Conceito e Ideia do Projeto

A MW Soluções nasceu da necessidade de gerenciar o ciclo de vida de atendimentos técnicos: desde o cadastro de clientes até a abertura, acompanhamento e fechamento de Ordens de Serviço (OS).

Diferente de sistemas simplistas que funcionam apenas como cadastros de dados, este projeto foi construído sob a filosofia de Domínio Rico (Rich Domain). Isso significa que as entidades criadas não são meras portadoras de dados, mas possuem inteligência própria para validar regras e proteger o estado do sistema.

## Pilares de Programação e Conceitos C# Aplicados

O desenvolvimento deste software serviu como um laboratório prático para diversos conceitos fundamentais da plataforma .NET:

- **Encapsulamento Avançado**: Uso rigoroso de modificadores de acesso para garantir que as propriedades de uma classe só possam ser alteradas por métodos autorizados. Isso evita que o sistema entre em estados inválidos (ex: um preço negativo ou um status de pedido incoerente).
- **Abstração e Herança**: Implementação de uma estrutura de classes onde Client herda de Person, permitindo o reaproveitamento de atributos comuns (Nome, CPF, Endereço) enquanto especializa comportamentos específicos do cliente.
- **Polimorfismo**: Capacidade de tratar objetos de forma genérica ou específica conforme a necessidade das camadas de serviço.
- **Injeção de Dependência (DI)**: Utilização do pacote Microsoft.Extensions.DependencyInjection para gerenciar o ciclo de vida das classes. Isso remove o acoplamento forte (evitando o uso excessivo de new) e permite que os componentes do sistema sejam facilmente substituíveis e testáveis.
- **Construtores Inteligentes**: Uso de construtores para orquestrar a criação de objetos já validados. Se um objeto nasce, ele nasce "limpo" e pronto para o uso.
- **LINQ (Language Integrated Query) & Collections**: Manipulação de listas genéricas (List<T>) para buscas complexas, filtragens de status e cálculos financeiros (como a soma total de serviços) de forma performática e legível.
- **Tratamento de Exceções Customizadas**: Implementação da exceções personalizadas para separar falhas técnicas de infraestrutura de erros de lógica de negócio comunicáveis ao usuário.

## Estrutura e Arquitetura

O projeto segue uma arquitetura multicamadas inspirada em padrões de mercado como DDD (Domain-Driven Design) e Clean Architecture, dividindo-se nas seguintes responsabilidades:

#### Entities (Camada de Domínio)

Esta é a camada mais interna e importante. Ela contém as regras de negócio puras e os modelos de dados.

Função: Validar se um preço é positivo, se um CPF é válido ou se uma ordem pode ser fechada. Não conhece nada sobre banco de dados ou interface visual.

#### Services (Camada de Negócio)

Responsável por orquestrar as operações do sistema. O serviço é o "maestro" que une as entidades e os repositórios.

Função: Se o usuário quer criar uma Ordem, o OrderService busca o Cliente no repositório, verifica se ele não está bloqueado, calcula os valores e manda salvar.

#### Repositories (Camada de Infraestrutura/Dados)

Abstrai a forma como os dados são guardados. Segue o Repository Pattern.

Função: Oferecer métodos simples como GetById, Save e Delete. O resto do sistema não sabe se os dados estão num banco SQL ou numa lista em memória.

#### Views (Camada de Interface)

Gerencia a interação com o usuário final.

Função: Contém os comandos Console.WriteLine e Console.ReadLine. Captura o que o usuário digita e envia para os Serviços processarem.

5. Data / Mocks

Simula o banco de dados propriamente dito.

Função: Armazenar as listas estáticas que mantêm os dados vivos enquanto o programa está em execução.

--- 

⚠️ Observações de Design

Para manter o foco no aprendizado de lógica e arquitetura, algumas decisões simplificadoras foram tomadas:

Persistência em Memória: O projeto não utiliza um banco de dados relacional (como SQL Server). Os dados são armazenados em static List<T>. Ao encerrar a aplicação, os dados são resetados. Isso foi feito para priorizar o estudo de Collections e LINQ.

Identificadores Híbridos: Utilizamos Guid para identificação técnica única e int para IDs amigáveis ao usuário (como o ID do Cliente), demonstrando como lidar com diferentes tipos de chaves.

Injeção de Dependência via Console: Embora o DI seja nativo da Web (ASP.NET), configuramos manualmente no Program.cs para demonstrar como o motor de dependências funciona "por baixo dos panos".

## Fluxo de Funcionamento

O sistema segue um fluxo linear e protegido para cada ação do usuário. Abaixo, o exemplo do fluxo de "Criação de uma Ordem de Serviço":

1. Entrada (View): O utilizador acede ao OrderView e fornece o ID do Cliente e os IDs dos serviços desejados.

2. Orquestração (Service): O OrderService entra em ação. Ele solicita ao ClientRepository os dados do cliente e ao MaintenanceRepository os dados dos serviços.

3. Validação de Negócio (Service): O serviço verifica se o cliente está ativo. Se estiver bloqueado, lança uma NegocioException. Verifica também se os serviços estão marcados como "Disponíveis".

4. Processamento (Entity): Caso as regras de negócio externas passem, a entidade Order é instanciada. Durante a construção, ela gera o seu próprio código único (OrderCode) e valida internamente se a descrição não é nula.

5. Persistência (Repository): O serviço envia o objeto pronto para o OrderRepository, que o adiciona à lista global de dados.

6. Resposta (View): O utilizador recebe a confirmação e o código da OS gerada. Qualquer erro durante o processo é capturado pelo try-catch global no Program.cs e exibido de forma amigável.

Como Executar

Para rodar este projeto localmente, siga os passos abaixo:

Pré-requisitos

.NET SDK 6.0 ou superior instalado.

Passo 1: Dependências

O projeto utiliza o container de DI oficial da Microsoft. Instale o pacote via terminal na pasta raiz:

`dotnet add package Microsoft.Extensions.DependencyInjection`

Passo 2: Compilação e Execução

Execute o comando de inicialização do .NET:

`dotnet run`


Passo 3: Utilização

Navegue pelos menus utilizando as teclas numéricas do teclado conforme as instruções no console. Os dados de teste (Mocks) já estarão pré-carregados para facilitar a navegação inicial.

Desenvolvido como projeto de consolidação de arquitetura em camadas e boas práticas de C#.
