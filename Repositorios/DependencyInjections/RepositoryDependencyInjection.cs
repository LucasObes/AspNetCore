using LojaRepositorios.DataBase;
using LojaRepositorios.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LojaRepositorios.DependencyInjections
{
    public static class RepositoryDependencyInjection
    {
        public static IServiceCollection AddRepositoryDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddRepositories()
                .AddDataBaseSqlServer(configuration);

            return services;
        }
        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

            return services;
        }

        private static IServiceCollection AddDataBaseSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServerArquivo");

            services.AddDbContext<LojaContexto>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}
