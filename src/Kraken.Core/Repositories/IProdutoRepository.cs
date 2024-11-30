using Kraken.Core.Entities;

namespace Kraken.Core.Repositories
{
    public interface IProdutoRepository
    {
        Task<Guid?> AdicionarAsync(ProdutoDto produtoDto);

        Task<List<ProdutoDto?>> BuscarPorPaginaAsync(string categoria, int quantidadePagina = 1, int registroPorPagina = 10);
    }
}