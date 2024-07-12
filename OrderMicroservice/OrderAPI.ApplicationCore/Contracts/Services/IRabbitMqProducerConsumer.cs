using Microsoft.Extensions.Logging;
using OrderAPI.ApplicationCore.Models.ResponseModels;

namespace OrderAPI.ApplicationCore.Contracts.Services;

public interface IRabbitMqProducerConsumer
{
    public void SendMessage<T>(T message);
    public IEnumerable<OrderResponseModel> ReadMessage(ILogger logger);
}