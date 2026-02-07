using MW_SOLUCOES.Entities;
using MW_SOLUCOES.Exceptions;
using MW_SOLUCOES.Repository;
using MW_SOLUCOES.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace MW_SOLUCOES.Services;

public class ClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public Client RegisterNewClient(Client client)
    {
        if (_clientRepository.GetClientByCPF(client.CPF) != null)
        {
            throw new NegocioException("O cliente já possui cadastro no sistema.");
        }

        try
        {
            var savedClient = _clientRepository.SaveClient(client);

            return savedClient ?? throw new NegocioException("Erro no salvamento do cliente.");
        }
        catch (Exception ex) when (ex is not NegocioException)
        {
            throw new Exception("Ocorreu um erro interno ao processar o cadastro.", ex);
        }
    }

    public Client GetClientById(int id)
    {
        var client = _clientRepository.GetClientById(id);

        if (client == null)
        {
            throw new NegocioException($"Cliente com ID {id} não encontrado.");
        }

        return client;
    }

    public List<Client> ListAll()
    {
        return _clientRepository.GetAllClients();
    }

    public Client GetByCPF(string cpf)
    {
        var client = _clientRepository.GetClientByCPF(cpf);
        if (client == null)
        {
            throw new NegocioException($"Cliente com CPF {cpf} não encontrado.");
        }

        return client;
    }

    public void UpdateClient(Client clientAtualizado)
    {
        var clienteExistente = _clientRepository.GetClientById(clientAtualizado.Id);

        if (clienteExistente == null)
        {
            throw new NegocioException("Tentativa de atualizar um cliente inexistente.");
        }

        if (clientAtualizado.CPF != clienteExistente.CPF)
        {
            var conflitoCpf = _clientRepository.GetClientByCPF(clientAtualizado.CPF);
            if (conflitoCpf != null && conflitoCpf.Id != clientAtualizado.Id)
            {
                throw new NegocioException("O novo CPF informado já pertence a outro cliente.");
            }
        }

        bool sucesso = _clientRepository.UpdateClient(clientAtualizado);

        if (!sucesso)
        {
            throw new NegocioException("Falha ao atualizar os dados do cliente.");
        }
    }

    public void RemoverCliente(int id)
    {
        var client = GetClientById(id);
        _clientRepository.DeleteClientById(client.Id);
    }
}