using KavsarApi.Services.AccountServices;

namespace KavsarApi.Extentions;
public static class DIExtention
{
    public static void InjectServices(this IServiceCollection services) {
        services.AddScoped<IAccountService, AccountService>();
    }

    public static void InitialServices(this IServiceCollection services,IConfiguration configuration) {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers();
        
        services.DbContextConfig(configuration);
        services.SwaggerConfig();
        services.AuthJwtConfig(configuration);
        services.InjectServices();
    }

    public async static void InitialMiddlewares(this WebApplication app)
    {
        try
        {
            var serviceProvider = app.Services.CreateScope().ServiceProvider;
            var dataContext = serviceProvider.GetRequiredService<DataContext>();
            await dataContext.Database.MigrateAsync();
        }
        catch (Exception) { }

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
    }
}