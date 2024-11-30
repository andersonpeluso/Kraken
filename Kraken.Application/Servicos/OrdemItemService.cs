using Kraken.Application.Models;
using Kraken.Application.Servicos.Contratos;
using Kraken.Core.Entities;
using Kraken.Core.Repositories;

namespace Kraken.Application.Servicos
{
    public sealed class OrdemItemService : IOrdemItemService
    {
        private readonly IOrdemItemRepository _ordemItemRepository;

        public OrdemItemService(IOrdemItemRepository ordemItemRepository)
        {
            _ordemItemRepository = ordemItemRepository;
        }

        public async Task<ResultadoAPI<object>> AdicionarAsync(List<OrdemItemModel> model)
        {
            ResultadoAPI<object>? resultado = null;

            try
            {
                if (model != null && model?.Count > 0)
                {
                    var entidades = CriarEntidade(model);

                    await _ordemItemRepository.AdicionarAsync(entidades);

                    resultado = new ResultadoAPI<object>(System.Net.HttpStatusCode.OK, model);
                }
                else
                    resultado = new ResultadoAPI<object>(System.Net.HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                resultado = new ResultadoAPI<object>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
            return resultado;
        }

        internal List<OrdemItemDto> CriarEntidade(List<OrdemItemModel> model)
        {
            var ordemItems = new List<OrdemItemDto>();

            foreach (var item in model)
            {
                var entidade = new OrdemItemDto();

                entidade.IdProduto = item.IdProduto;
                entidade.Quantidade = item.Quantidade;

                ordemItems.Add(entidade);
            }
            return ordemItems;
        }
    }
}