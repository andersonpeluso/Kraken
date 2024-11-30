using Kraken.Application.Models;

namespace Kraken.Application.Servicos.Contratos
{
    public interface IProdutoService
    {
        Task<ResultadoAPI<object>> AdicionarAsync(ProdutoModel model);

        Task<ResultadoAPI<object>> BuscarPorPaginaAsync(string categoria, int quantidadePagina = 1, int registroPorPagina = 10);
    }
}