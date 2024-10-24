using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

namespace OllieShop.RabbitMQApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly string _queueName = "OllieQueue";
        private readonly string _hostName = "localhost";

        // POST api/message - Mesaj gönderme işlemi
        [HttpPost]
        public IActionResult CreateMessage()
        {
            // RabbitMQ bağlantı ve kanal oluşturma
            var connectionFactory = new ConnectionFactory() { HostName = _hostName };

            using (var connection = connectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // Kuyruk oluşturma
                channel.QueueDeclare(queue: _queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var messageContent = "Hello, this is an Ollie Queue message!";
                var byteMessageContent = Encoding.UTF8.GetBytes(messageContent);

                // Mesajı kuyruğa gönderme
                channel.BasicPublish(exchange: "",
                                     routingKey: _queueName,
                                     basicProperties: null,
                                     body: byteMessageContent);
            }

            // Mesaj başarılı bir şekilde kuyruğa gönderildi
            return Ok("Your message has been queued.");
        }

        // GET api/message - Mesaj okuma işlemi
        [HttpGet]
        public IActionResult ReadMessage()
        {
            string message = string.Empty;

            // RabbitMQ bağlantı ve kanal oluşturma
            var factory = new ConnectionFactory() { HostName = _hostName };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // Mesajı dinlemek için bir consumer oluşturuyoruz
                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var byteMessage = ea.Body.ToArray();
                    message = Encoding.UTF8.GetString(byteMessage);

                    // Mesaj başarıyla işlendiğini RabbitMQ'ya bildiriyoruz
                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                };

                // Mesajı kuyruğa bağlanıp dinliyoruz
                channel.BasicConsume(queue: _queueName,
                                     autoAck: false, // Mesajın başarıyla işlendiğini manuel olarak bildiriyoruz.
                                     consumer: consumer);

                // Küçük bir gecikme ekleyebiliriz ki mesaj okunurken boş dönmesin
                System.Threading.Thread.Sleep(1000);
            }

            // Eğer mesaj bulunamadıysa, boş mesaj dönelim
            if (string.IsNullOrEmpty(message))
                return Ok("No message found in the queue.");

            // Mesaj başarıyla okundu
            return Ok($"Received message: {message}");
        }
    }
}
