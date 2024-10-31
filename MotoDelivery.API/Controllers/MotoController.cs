using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotoDelivery.Application.Commands;

namespace MotoDelivery.API.Controllers
{
    [ApiController]
    [Route("api/motos")]
    public class MotoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MotoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMoto([FromBody] CreateMotoCommand command)
        {
            try
            {
                var motoId = await _mediator.Send(command);
                return CreatedAtAction(nameof(GetMotoById), new { id = motoId }, command);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMotoById(Guid id)
        {
            var moto = await _mediator.Send(new GetMotoByIdQuery { MotoId = id });
            if (moto == null)
            {
                return NotFound(new { mensagem = "Moto não encontrada" });
            }

            return Ok(moto);
        }

        [HttpPut("{id}/placa")]
        public async Task<IActionResult> UpdateMotoPlaca(Guid id, [FromBody] UpdateMotoPlacaCommand command)
        {
            try
            {
                command.MotoId = id;
                await _mediator.Send(command);
                return Ok(new { mensagem = "Placa modificada com sucesso" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoto(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteMotoCommand { MotoId = id });
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMotos([FromQuery] string placa)
        {
            var motos = await _mediator.Send(new GetMotosQuery { Placa = placa });
            return Ok(motos);
        }
    }
}
