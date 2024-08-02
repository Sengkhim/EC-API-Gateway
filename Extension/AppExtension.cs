namespace EC_APIGateway.Extension;

public static class AppExtension
{
    public static void BatchConfig(this  WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseIdentityServer();
        app.MapControllers();
    }
}