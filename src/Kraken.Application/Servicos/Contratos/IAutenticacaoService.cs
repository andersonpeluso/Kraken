using Kraken.Application.Models;

namespace Kraken.Application.Servicos.Contratos
{
    public interface IAutenticacaoService
    {
        Task<ResultadoAPI<object>> AutenticarAsync(string login, string chave);
    }
}