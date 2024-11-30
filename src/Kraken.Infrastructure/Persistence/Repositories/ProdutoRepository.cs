using Kraken.Core.Entities;
using Kraken.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kraken.Infrastructure.Persistence.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly KrakenDbContext _context;

        public ProdutoRepository(KrakenDbContext context)
        {
            _context = context;
        }

        public async Task<Guid?> AdicionarAsync(ProdutoDto produtoDto)
        {
            await _context.Produtos.AddAsync(produtoDto);
            await _context.SaveChangesAsync();

            return produtoDto.Id;
        }

        public async Task<List<ProdutoDto?>> BuscarPorPaginaAsync(string categoria, int quantidadePagina = 1, int registroPorPagina = 10)
        {
            int skip = (quantidadePagina - 1) * registroPorPagina;

            IQueryable<ProdutoDto> query = _context.Produtos;

            if (!string.IsNullOrEmpty(categoria))
                query = query.Where(p => p.Categoria == categoria);

            query = query.OrderBy(p => p.Categoria);

            List<ProdutoDto> entidades = await query
                .Skip(skip)
                .Take(registroPorPagina)
                .ToListAsync();

            return entidades;
        }
    }
}