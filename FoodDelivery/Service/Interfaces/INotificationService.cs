namespace FoodDelivery.Service.Interfaces;

public interface INotificationService
{
    Task SendToQueue(string message);
}