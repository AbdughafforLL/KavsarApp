namespace KavsarApi.Extentions;
internal static class DbContextExtention
{
    internal static void DbContextConfig(this IServiceCollection services,IConfiguration configuration) {
        var con = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<DataContext>(c => c.UseNpgsql(con));
    }
}