using System.Collections.Concurrent;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Stores;

namespace EC_APIGateway.ClientStore;

public class CustomClientStore : IClientStore
{
    private readonly ConcurrentDictionary<string, Client> _clients = new ();

    public Task<Client> FindClientByIdAsync(string clientId)
    {
        _clients.TryGetValue(clientId, out var client);
        return Task.FromResult(client!);
    }

    public Task AddClient(Client client)
    {
        _clients[client.ClientId] = client;
        return Task.FromResult(client!);
    }
}
 