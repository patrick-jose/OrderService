using System.Text;
using OrderService.Data.Models;
using OrderService.Utils;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var log = new LogWriter();

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "hello",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

log.LogWrite(" [*] Waiting for messages.");

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    log.LogWrite($" [x] Received {message}");

    var order = new CustomerOrderModel() { CustomerId = 3, OrderId = 1002, ProductId = 5, Quantity = 10, UnitaryPrice = 20 };


};
channel.BasicConsume(queue: "hello",
                     autoAck: true,
                     consumer: consumer);