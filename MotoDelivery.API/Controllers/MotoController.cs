using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotoDelivery.Application.Commands;
using MotoDelivery.Application.Requests.MotoRequests;

namespace MotoDelivery.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<IActionResult> PostMoto([FromBody] MotoRequest request)
        {
            // Enviar comando para cadastrar moto
            var response = await _mediator.Send(new CadastrarMotoCommand(request));
            if (response.Sucesso)
                return StatusCode(StatusCodes.Status201Created);

            return BadRequest(new { mensagem = "Dados inválidos" });
        }

        /// <summary>
        /// Consultar motos existentes
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMotos([FromQuery] string placa)
        {
            var motos = await _mediator.Send(new ConsultarMotosQuery(placa));
            return Ok(motos);
        }

        /// <summary>
        /// Consultar moto por id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMotoById(string id)
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
        public async Task<IActionResult> UpdatePlacaMoto(string id, [FromBody] ModificarPlacaMotoRequest request)
        {
            var response = await _mediator.Send(new ModificarPlacaMotoCommand(id, request.Placa));
            if (response.Sucesso)
                return Ok(new { mensagem = "Placa modificada com sucesso" });

            return BadRequest(new { mensagem = "Dados inválidos" });
        }

        /// <summary>
        /// Remover uma moto
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoto(string id)
        {
            var response = await _mediator.Send(new RemoverMotoCommand(id));
            if (response.Sucesso)
                return Ok();

            return BadRequest(new { mensagem = "Dados inválidos" });
        }
    }
}
