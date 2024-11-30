using Kraken.Application.Servicos;
using Kraken.Application.Servicos.Contratos;
using Kraken.Core.Repositories;
using Kraken.Infrastructure.Persistence.Repositories;

namespace Kraken.API.IoC
{
    public static class InjecaoDependencia
    {
        /// <summary>
        /// Injetar dependências.
        /// </summary>
        /// <param name="services">Serviços</param>
        /// <param name="configuration">Configuração</param>
        /// <returns></returns>
        public static IServiceCollection AdicionarServicos(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            //services.Configure<ConfiguracaoDTO>(configuration.GetSection("ConfiguracaoToken"));

            // Service
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // ASPNET
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IOrdemItemService, OrdemItemService>();
            //services.AddScoped<IAutenticacaoServico, AutenticacaoServico>();

            // Repositorio
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IOrdemItemRepository, OrdemItemRepository>();

            return services;
        }

        /// <summary>
        /// Ler arquivos de configuração.
        /// </summary>
        /// <param name="services">Serviço</param>
        /// <param name="configuration">Configuração</param>
        /// <returns></returns>
        public static IServiceCollection LerArquivoConfiguracao(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            //services.Configure<ConfiguracaoSefazDTO>(configuration.GetSection("SintegraApi"));
            //services.Configure<ConexaoDTO>(configuration.GetSection("ConnectionStrings"));

            return services;
        }
    }
}