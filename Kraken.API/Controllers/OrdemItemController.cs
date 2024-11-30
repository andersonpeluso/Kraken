using Kraken.Application.Models;
using Kraken.Application.Servicos.Contratos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kraken.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdemItemController : ControllerBase
    {
        private readonly IOrdemItemService _ordemItemService;

        public OrdemItemController(IOrdemItemService ordemItemService)
        {
            _ordemItemService = ordemItemService;
        }

        /// <summary>
        /// Inserir um novo registro no sistema.
        /// </summary>
        /// <param name="viewModel">View Model</param>
        /// <returns>ActionResult</returns>
        /// <response code="201">Objeto criado.</response>
        /// <response code="500">Retorna para erro interno.</response>
        [HttpPost]
        [ProducesResponseType(typeof(ResultadoAPI<object>), 200)]
        [ProducesResponseType(typeof(ResultadoAPI<object>), 500)]
        public async Task<ActionResult> AdicionarAsync(List<OrdemItemModel> viewModel)
        {
            var resultado = await _ordemItemService.AdicionarAsync(viewModel);

            return StatusCode((int)resultado.Status, string.IsNullOrEmpty(resultado.Mensagem) ? resultado.Dados : resultado.Mensagem);
        }
    }
}