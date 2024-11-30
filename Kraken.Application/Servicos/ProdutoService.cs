using Kraken.Application.Models;
using Kraken.Application.Servicos.Contratos;
using Kraken.Core.Entities;
using Kraken.Core.Repositories;

namespace Kraken.Application.Servicos
{
    public sealed class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<ResultadoAPI<object>?> AdicionarAsync(ProdutoModel model)
        {
            ResultadoAPI<object>? resultado = null;

            try
            {
                if (model != null)
                {
                    var entidade = CriarEntidade(model);

                    await _produtoRepository.AdicionarAsync(entidade);

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

        public async Task<ResultadoAPI<object>?> BuscarPorPaginaAsync(string categoria, int quantidadePagina = 1, int registroPorPagina = 10)
        {
            ResultadoAPI<object>? resultado = null;

            try
            {
                var entidades = await _produtoRepository.BuscarPorPaginaAsync(categoria, quantidadePagina, registroPorPagina);

                resultado = new ResultadoAPI<object>(System.Net.HttpStatusCode.OK, entidades);
            }
            catch (Exception ex)
            {
                resultado = new ResultadoAPI<object>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
            return resultado;
        }

        public ProdutoDto CriarEntidade(ProdutoModel model)
        {
            var entidade = new ProdutoDto
            {
                Nome = model.Nome,
                Categoria = model.Categoria,
                Preco = model.Preco
            };

            return entidade;
        }
    }
}