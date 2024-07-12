
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Models.ResponseModels;

namespace Infrastructure.Implementation.Service
{
    public class RabitMqProducerConsumer : IRabbitMqProducerConsumer
    {
        public IEnumerable<OrderResponseModel> ReadMessage(ILogger logger)
        {
            var _list = new List<string>();

            // Setup synchronization event. 
            //var msgsRecievedGate = new ManualResetEventSlim(false);

            var factory = new ConnectionFactory() 
            {
                HostName = "localhost", // RabbitMQ server hostname
                Port = 5672,            // RabbitMQ server port
                UserName = "guest",     // RabbitMQ username
                Password = "guest"      // RabbitMQ password
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var response = channel.QueueDeclare(queue: "order", durable: true, exclusive: false, autoDelete: true, arguments: null);

                var msgCount = response.MessageCount;
                var msgRecieved = 0;

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += async (model, ea) =>
                {
                    msgRecieved++;

                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    _list.Add(message);
                };

                //msgsRecievedGate.Wait(10000);
                channel.BasicConsume(queue: "order", autoAck: false, consumer: consumer);
            }

            List<OrderResponseModel> orderViewModels = new List<OrderResponseModel>();
            logger.LogInformation($"Received message: {_list.Count()}");
            foreach (var jsonString in _list)
            {
                OrderResponseModel orderViewModel = JsonConvert.DeserializeObject<OrderResponseModel>(jsonString);
                orderViewModels.Add(orderViewModel);
            }

            return orderViewModels;
        }

        public void SendMessage<T>(T message)
        {
            //Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
            var factory = new ConnectionFactory
            {
                HostName = "localhost", // RabbitMQ server hostname
                Port = 5672,            // RabbitMQ server port
                UserName = "guest",     // RabbitMQ username
                Password = "guest"
            };
            var connection = factory.CreateConnection();
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("order", durable: true, exclusive: false, autoDelete: true, arguments: null);
                //Serialize the message
                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);
                //put the data on to the order queue
                channel.BasicPublish(exchange: "", routingKey: "order", basicProperties: null, body: body);
            }
               
        }
    }
}
