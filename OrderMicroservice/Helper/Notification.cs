using System.Text;
using RabbitMQ.Client;
namespace OrderMicroserviceAPI.Helper
{
	public class Notification
	{
		ConnectionFactory connectionFactory;
		public Notification()
		{
			connectionFactory = new ConnectionFactory();
			
		}

		public void AddMessageToQueue(string message) {
            connectionFactory.Uri = new Uri("amqp://guest:guest@localhost:5672");

            connectionFactory.ClientProvidedName = "Order Service";


            //create a connection
            var connection = connectionFactory.CreateConnection();
            
                //create a channel
                var channel = connection.CreateModel();

                //create an exchange
                string exchange = "OrderAPIExchange";

                //initialize routing key to connect messages with exchange
                string routingKey = "order-api-routing-key";

                string queueName = "order-api-queue";
                channel.ExchangeDeclare(exchange, ExchangeType.Direct);
                channel.QueueDeclare(queueName,false, false, false,null);
                channel.QueueBind(queueName, exchange, routingKey, null);

                //converting string message to byte
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange, routingKey, null, messageBytes);
                channel.Close();
                connection.Close();
            

        }
	}
}

