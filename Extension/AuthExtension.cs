using Duende.IdentityServer.Models;
using EC_APIGateway.ClientStore;
using EC_APIGateway.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EC_APIGateway.Extension;

public static class AuthExtension
{
    public static void AddOAuth2Configuration(this IServiceCollection service, IConfiguration configuration)
    {
        var authenticationOptions = new AuthenticationOptions();
        configuration.GetSection("Authentication").Bind(authenticationOptions);

        service.AddSingleton(authenticationOptions);
        
        var providerKey = Environment.GetEnvironmentVariable("IDENTITY_PROVIDER") ?? "Provider1";
        var selectedProvider = authenticationOptions.IdentityProviders[providerKey];

        service.AddAuthentication(authenticationOptions.DefaultScheme).AddJwtBearer(options => {
            options.Authority = selectedProvider.Authority;
            options.Audience = selectedProvider.Audience;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = selectedProvider.ValidateIssuer,
                ValidateAudience = selectedProvider.ValidateAudience,
                ValidateLifetime = selectedProvider.ValidateLifetime,
                ValidateIssuerSigningKey = selectedProvider.ValidateIssuerSigningKey,
                ValidIssuer = selectedProvider.ValidIssuer,
                ValidAudience = selectedProvider.ValidAudience
            };
        });
    }

    public static void AddConfigIdentityServer(this IServiceCollection service)
    {
        service.AddSingleton<CustomClientStore>();
        service.AddIdentityServer()
            .AddClientStore<CustomClientStore>()
            .AddInMemoryApiScopes(new List<ApiScope>
            {
                new("api1", "My API")
            })
            .AddDeveloperSigningCredential();
    }
}