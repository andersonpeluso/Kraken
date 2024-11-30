using Kraken.Core.Entities;
using Kraken.Core.Repositories;

namespace Kraken.Infrastructure.Persistence.Repositories
{
    public class OrdemItemRepository : IOrdemItemRepository
    {
        private readonly KrakenDbContext _context;

        public OrdemItemRepository(KrakenDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(List<OrdemItemDto> ordemItems)
        {
            if (ordemItems == null || ordemItems.Count == 0)
                throw new ArgumentException("A lista de item não pode ser nula ou vazia.");

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                foreach (var ordemItem in ordemItems)
                    await _context.OrdemItens.AddAsync(ordemItem);

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                Console.WriteLine($"Erro ao adicionar item: {ex.Message}");

                throw;
            }
        }
    }
}