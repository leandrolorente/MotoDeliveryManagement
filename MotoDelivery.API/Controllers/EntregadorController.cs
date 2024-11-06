using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotoDelivery.Application.Commands;
using MotoDelivery.Application.Requests.EntregadorRequests;
using Swashbuckle.AspNetCore.Annotations;

namespace MotoDelivery.API.Controllers
{
    [ApiController]
    [Route("entregadores")]
    [Tags("entregadores")]
    public class EntregadorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EntregadorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Cadastrar um entregador
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(Summary = "Cadastrar entregador")]
        public async Task<IActionResult> PostEntregador([FromBody] CadastrarEntregadorRequest request)
        {
            var response = await _mediator.Send(new CreateEntregadorCommand(request));
            if (response != 0)
                return StatusCode(StatusCodes.Status201Created);

            return BadRequest(new { mensagem = "Dados inválidos" });
        }

        /// <summary>
        /// Enviar foto da CNH
        /// </summary>
        [HttpPost("{id}/cnh")]
        [SwaggerOperation(Summary = "Enviar foto CNH")]
        public async Task<IActionResult> PostFotoCNH(long id, [FromBody] EnviarFotoCNHRequest request)
        {
          /*  if (!long.TryParse(id, out var entregadorId))
            {
                return BadRequest(new { mensagem = "ID inválido. O ID deve ser um GUID válido." });
            }*/

            // Verifica se o arquivo foi enviado
            if (request.ImagemCNH == null || request.ImagemCNH.Length == 0)
            {
                return BadRequest(new { mensagem = "Arquivo de imagem inválido ou não enviado." });
            }

            var response = await _mediator.Send(new EnviarFotoCNHCommand(id, request.ImagemCNH));
            if (response)
                return Ok();

            return BadRequest(new { mensagem = "Dados inválidos" });
        }
    }
}
