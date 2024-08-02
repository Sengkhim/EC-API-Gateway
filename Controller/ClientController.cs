using Duende.IdentityServer.Models;
using EC_APIGateway.ClientStore;
using Microsoft.AspNetCore.Mvc;

namespace EC_APIGateway.Controller;

[ApiController]
[Microsoft.AspNetCore.Components.Route("[controller]")]
public class ClientController(CustomClientStore clientStore) : ControllerBase
{
    [HttpPost]
    public IActionResult RegisterClient(string clientId, string clientSecret)
    {
        var client = new Client
        {
            ClientId = clientId,
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            ClientSecrets = { new Secret(clientSecret.Sha256()) },
            AllowedScopes = { "api1" }
        };
        
        clientStore.AddClient(client);
        return Ok();
    }
}