using Kraken.Core.Entities;

namespace Kraken.Core.Repositories
{
    public interface IOrdemItemRepository
    {
        Task AdicionarAsync(List<OrdemItemDto> produtos);
    }
}