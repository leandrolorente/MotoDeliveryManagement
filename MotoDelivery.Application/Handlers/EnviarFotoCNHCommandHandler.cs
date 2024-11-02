using MediatR;
using MotoDelivery.Application.Commands;
using MotoDelivery.Application.Interfaces;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Handlers
{
    /// <summary>
    /// Handler responsável por processar o envio da foto da CNH.
    /// </summary>
    public class EnviarFotoCNHCommandHandler : IRequestHandler<EnviarFotoCNHCommand, bool>
    {
        private readonly IEntregadorRepository _entregadorRepository;

        public EnviarFotoCNHCommandHandler(IEntregadorRepository entregadorRepository)
        {
            _entregadorRepository = entregadorRepository;
        }

        /// <summary>
        /// Manipula o comando de envio da foto da CNH.
        /// </summary>
        /// <param name="request">Comando de envio da foto da CNH</param>
        /// <param name="cancellationToken">Token de cancelamento</param>
        /// <returns>Indica se o envio foi bem-sucedido</returns>
        public async Task<bool> Handle(EnviarFotoCNHCommand request, CancellationToken cancellationToken)
        {
            var entregador = await _entregadorRepository.GetByIdAsync(request.EntregadorId);

            if (entregador == null)
            {
                throw new KeyNotFoundException("Entregador não encontrado.");
            }

            // Exemplo de lógica para salvar a foto da CNH
            var filePath = Path.Combine("caminho/para/armazenamento", $"{request.EntregadorId}_CNH.jpg");
            /*using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await request.FotoCnh.CopyToAsync(stream);
            }*/

            return true;
        }
    }
}