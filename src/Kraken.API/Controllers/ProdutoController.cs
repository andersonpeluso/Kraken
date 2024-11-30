using Kraken.Application.Models;
using Kraken.Application.Servicos.Contratos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kraken.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        /// <summary>
        /// Inserir um novo registro no sistema.
        /// </summary>
        /// <param name="model">View Model</param>
        /// <returns>ActionResult</returns>
        /// <response code="201">Objeto criado.</response>
        /// <response code="406">Caso não seja informado o e-mail.</response>
        /// <response code="500">Retorna para erro interno.</response>
        [HttpPost]
        [ProducesResponseType(typeof(ResultadoAPI<object>), 200)]
        [ProducesResponseType(typeof(ResultadoAPI<object>), 406)]
        [ProducesResponseType(typeof(ResultadoAPI<object>), 500)]
        public async Task<ActionResult> AdicionarAsync(ProdutoModel model)
        {
            var resultado = await _produtoService.AdicionarAsync(model);

            return StatusCode((int)resultado.Status, string.IsNullOrEmpty(resultado.Mensagem) ? resultado.Dados : resultado.Mensagem);
        }

        /// <summary>
        /// Recuperar todos os registros armazenados no sistema.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Resultado esparado.</response>
        /// <response code="500">Retorna para erro interno.</response>
        [HttpGet]
        [ProducesResponseType(typeof(ResultadoAPI<object>), 200)]
        [ProducesResponseType(typeof(ResultadoAPI<object>), 500)]
        public async Task<ActionResult> BuscarAsync(string categoria, int quantidadePagina = 1, int registroPorPagina = 10)
        {
            var resultado = await _produtoService.BuscarPorPaginaAsync(categoria, quantidadePagina, registroPorPagina);

            return StatusCode((int)resultado.Status, string.IsNullOrEmpty(resultado.Mensagem) ? resultado.Dados : resultado.Mensagem);
        }
    }
}