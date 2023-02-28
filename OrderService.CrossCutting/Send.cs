using OrderService.Utils;
using RabbitMQ.Client;
using System.Text;

namespace OrderService.CrossCutting
{
    public class Send : ISend
    {
        private LogWriter log;
        public async void SendMessage(string message)
        {
            try
            {
                log = new LogWriter();

                var factory = new ConnectionFactory { HostName = "localhost" };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                message = "Hello World!";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "hello",
                                 basicProperties: null,
                                 body: body);

                log.LogWrite($" [x] Sent {message}");
            }
            catch (Exception ex) 
            { 
                throw ex; 
            }
        }

    }
}