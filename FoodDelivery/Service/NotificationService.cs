using FoodDelivery.Service.Interfaces;
using Google.Cloud.PubSub.V1;

namespace FoodDelivery.Service;

public class NotificationService : INotificationService
{
    private const string projectId = "iconic-access-376809";
    private const string topicId = "food-delivery-pub";
    private readonly PublisherClient _publisher;

    public NotificationService()
    {
        _publisher = PublisherClient.Create(new TopicName(projectId, topicId));
    }

    public async Task SendToQueue(string message)
    {
        await _publisher.PublishAsync(message);
    }
}