using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace EShop.RabbitMqMessage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateMessage()
        {
            var connectionFactory = new ConnectionFactory() 
            { 
                HostName = "localhost"
            };
            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("Quequ1" , false , false , false , null);
            var msgContent = "rabbitmq queue message";
            var bytemessage = Encoding.UTF8.GetBytes(msgContent);
            channel.BasicPublish(exchange:"" , routingKey: "Quequ1" , basicProperties:null,body:bytemessage);
            return Ok();
        }

        [HttpGet]
        public IActionResult ReadMessage()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, x) =>
            {
                var byteMessage = x.Body.ToArray();
                var message = Encoding.UTF8.GetString(byteMessage);
            };
            channel.BasicConsume(queue: "Quequ1", autoAck: false, consumer: consumer);
            return Ok();
        }
    }
}
