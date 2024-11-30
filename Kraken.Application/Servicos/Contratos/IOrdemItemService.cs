using Kraken.Application.Models;

namespace Kraken.Application.Servicos.Contratos
{
    public interface IOrdemItemService
    {
        Task<ResultadoAPI<object>> AdicionarAsync(List<OrdemItemModel> model);
    }
}