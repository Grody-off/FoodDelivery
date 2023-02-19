using FoodDelivery.Service.Interfaces;
using Google.Cloud.PubSub.V1;

namespace FoodDelivery.Service;

public class MessageBgJob : BackgroundService
{
    private const string ProjectId = "iconic-access-376809";
    private const string SubscriptionId = "food-delivery-sub-sub";
    private readonly ILogger<MessageBgJob> _logger;
    private readonly IServiceProvider _serviceProvider;

    public MessageBgJob(ILogger<MessageBgJob> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var subscriptionName = new SubscriptionName(ProjectId, SubscriptionId);
        var subscriber = await SubscriberClient.CreateAsync(subscriptionName);
        await subscriber.StartAsync(async (msg, _) =>
        {
            Console.WriteLine($"Received message {msg.MessageId} published at {msg.PublishTime.ToDateTime()}");

            var data = msg.Data.ToStringUtf8();
            Console.WriteLine($"Text: '{data}'");
            
            var dataContent = data.Split(" ");
            
            bool.TryParse(dataContent.Last(), out var isSuccess);

            if (!isSuccess)
            {
                var orderId = int.Parse(dataContent.First());
                
                using var scope = _serviceProvider.CreateScope();
                var orderService = scope.ServiceProvider.GetRequiredService<IOrderService>();

                var order = await orderService.GetById(orderId);
                await orderService.Remove(order);

                var message = $"order {orderId} was removed";
                Console.WriteLine(message);
                _logger.LogInformation(message);
            }
            
            return SubscriberClient.Reply.Ack;
        });
    }
}