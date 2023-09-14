using FinancialStore.Contracts.Data.Transactions;
using FinancialStore.Infra.Data;
using FinancialStore.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialStore.Infra
{
    public static class ServiceExtensions
    {
        private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddNpgsql<DatabaseContext>(configuration.GetConnectionString("DefaultConnection"), (options) =>
            {
                options.MigrationsAssembly("FinancialStore.Migrations");
            });
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDatabaseContext(configuration).AddUnitOfWork();
        }
    }
}
