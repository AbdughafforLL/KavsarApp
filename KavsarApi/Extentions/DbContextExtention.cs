namespace KavsarApi.Extentions;
public static class DbContextExtention
{
    public static void DbContextConfig(this IServiceCollection services,IConfiguration configuration) {
        var con = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<DataContext>(c => c.UseNpgsql(con));
    }
}