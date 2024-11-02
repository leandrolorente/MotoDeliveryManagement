namespace MotoDelivery.Application.Interfaces
{
    /// <summary>
    /// Interface que define o contrato para um barramento de mensagens.
    /// </summary>
    public interface IMessageBus
    {
        /// <summary>
        /// Publica uma mensagem em uma fila específica.
        /// </summary>
        /// <typeparam name="T">O tipo da mensagem.</typeparam>
        /// <param name="queueName">O nome da fila onde a mensagem será publicada.</param>
        /// <param name="message">A mensagem a ser publicada.</param>
        void Publish<T>(string queueName, T message);
    }
}