using Kraken.Core.Repositories;
using Kraken.Infrastructure.Persistence;
using Kraken.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kraken.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories().AddData(configuration);

            return services;
        }

        private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Primario");
            services.AddDbContext<KrakenDbContext>(o => o.UseSqlServer(connectionString));

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            //services.AddScoped<IProjectRepository, ProjectRepository>();
            //services.AddScoped<ISkillRepository, SkillRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}