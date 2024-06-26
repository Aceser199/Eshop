using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        //services.AddDbContext<ApplicationDbContext>(options =>
        //    options.UseSqlServer(connectionString,
        //        sqlServerOptionsAction: sqlOptions =>
        //        {
        //            sqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).GetTypeInfo().Assembly.GetName().Name);
        //            sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
        //        }));

        //services.AddScooped<IApplicationDbContext, ApplicationDbContext>();
        //services.AddTransient<IOrderRepository, OrderRepository>();

        return services;
    }
}
