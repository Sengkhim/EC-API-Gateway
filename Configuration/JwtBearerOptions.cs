namespace EC_APIGateway.Configuration;

public class JwtBearerOptions
{
    public string Authority { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public bool ValidateIssuer { get; set; } 
    public bool ValidateAudience { get; set; }
    public bool ValidateLifetime { get; set; }
    public bool ValidateIssuerSigningKey { get; set; }
    public string ValidIssuer { get; set; } = string.Empty;
    public string ValidAudience { get; set; } = string.Empty;
}

public class AuthenticationOptions
{
    public string DefaultScheme { get; set; } = string.Empty;
    public Dictionary<string, JwtBearerOptions> IdentityProviders { get; set; } = null!;
}
