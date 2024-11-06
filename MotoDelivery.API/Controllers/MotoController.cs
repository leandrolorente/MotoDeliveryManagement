using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotoDelivery.Application.Commands;
using MotoDelivery.Application.Handlers;
using MotoDelivery.Application.Queries.MotoQueries;
using MotoDelivery.Application.Requests.MotoRequests;
using Swashbuckle.AspNetCore.Annotations;

namespace MotoDelivery.API.Controllers
{
    [ApiController]
    [Route("/motos")]
    [Tags("motos")]
    public class MotoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MotoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Cadastrar uma nova moto
        /// </summary>
        /// <param name="request">Dados da moto</param>
        /// <returns>Resposta do cadastro</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(Summary = "Cadastrar uma nova moto")]
        public async Task<IActionResult> PostMoto([FromBody] CadastrarMotoRequest request)
        {
            var command = new CreateMotoCommand(
               request.Identificador,
               request.Ano,
               request.Modelo,
               request.Placa
           );

            // Enviar comando para cadastrar moto
            var response = await _mediator.Send(command);
            if (response != 0)
                return StatusCode(StatusCodes.Status201Created);

            return BadRequest(new { mensagem = "Dados inválidos" });
        }

        /// <summary>
        /// Consultar motos existentes
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Consultar motos existentes")]
        public async Task<IActionResult> GetMotos(string placa)
        {
            var motos = await _mediator.Send(new ConsultarMotosQuery(placa));
            return Ok(motos);
        }

        /// <summary>
        /// Consultar moto por id
        /// </summary>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Consultar motos existentes por id")]
        public async Task<IActionResult> GetMotoById(long id)
        {
            var moto = await _mediator.Send(new ConsultarMotoPorIdQuery(id));
            if (moto == null)
                return NotFound(new { mensagem = "Moto não encontrada" });

            return Ok(moto);
        }

        /// <summary>
        /// Modificar a placa de uma moto
        /// </summary>
        [HttpPut("{id}/placa")]
        [SwaggerOperation(Summary = "Modificar a placa de uma moto")]
        public async Task<IActionResult> UpdatePlacaMoto(string id, [FromBody] ModificarPlacaMotoRequest request)
        {
            if (!long.TryParse(id, out long motoId))
            {
                // Retorna um erro 400 se o formato do id for inválido
                return BadRequest(new { mensagem = "Dados inválidos" });
            }
            var response = await _mediator.Send(new UpdateMotoPlacaCommand(motoId, request.Placa));
            if (response.Sucesso)
                return Ok(new { mensagem = "Placa modificada com sucesso" });

            return BadRequest(new { mensagem = "Dados inválidos" });
        }

        /// <summary>
        /// Remover uma moto
        /// </summary>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remover uma moto")]
        public async Task<IActionResult> DeleteMoto(long id)
        {
            
            var response = await _mediator.Send(new RemoverMotoCommand(id));
            if (response)
                return Ok();

            return BadRequest(new { mensagem = "Dados inválidos" });
        }
    }
}
