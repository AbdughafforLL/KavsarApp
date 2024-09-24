using KavsarApi.AutoMapper;
using KavsarApi.Services.AccountServices;
using KavsarApi.Services.CarServices;

namespace KavsarApi.Extentions;
internal static class DIExtention
{
    internal static void InjectServices(this IServiceCollection services) {
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ICarService, CarService>();
    }

    internal static void InitialServices(this IServiceCollection services,IConfiguration configuration) {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers();
        services.AddAutoMapper(typeof(MapperProfile));

        services.DbContextConfig(configuration);
        services.SwaggerConfig();
        services.AuthJwtConfig(configuration);
        services.InjectServices();
    }

    internal static void InitialMiddlewares(this WebApplication app)
    {
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