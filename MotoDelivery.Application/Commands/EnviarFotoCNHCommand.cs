using MediatR;
using Microsoft.AspNetCore.Http;


namespace MotoDelivery.Application.Commands
{
    /// <summary>
    /// Comando para enviar a foto da CNH de um entregador.
    /// </summary>
    public class EnviarFotoCNHCommand : IRequest<bool>
    {
        public Guid EntregadorId { get; private set; }
        public string FotoCnh { get; private set; }

        /// <summary>
        /// Construtor do comando de envio de foto da CNH.
        /// </summary>
        /// <param name="entregadorId">Id do entregador</param>
        /// <param name="fotoCnh">Arquivo da foto da CNH</param>
        public EnviarFotoCNHCommand(Guid entregadorId, string fotoCnh)
        {
            EntregadorId = entregadorId;
            FotoCnh = fotoCnh;
        }
    }
}