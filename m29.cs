
using System;

namespace Task29_Notifications
{
    enum NotificationType
    {
        Email,
        Sms,
        Push
    }
    interface INotification
    {
        void Send(string message);
    }
    class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("Отправка Email: " + message);
        }
    }
    class SmsNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("Отправка SMS: " + message);
        }
    }
    class PushNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("Отправка Push: " + message);
        }
    }
    class NotificationFactory
    {
        public static INotification Create(NotificationType type)
        {
            switch (type)
            {
                case NotificationType.Email:
                    return new EmailNotification();
                case NotificationType.Sms:
                    return new SmsNotification();
                case NotificationType.Push:
                    return new PushNotification();
                default:
                    throw new ArgumentException("Неизвестный тип уведомления.");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            INotification email =
                NotificationFactory.Create(NotificationType.Email);
            INotification sms =
                NotificationFactory.Create(NotificationType.Sms);
            INotification push =
                NotificationFactory.Create(NotificationType.Push);
            email.Send("Здравствуйте! Ваш заказ оформлен.");
            sms.Send("Ваш заказ готов к выдаче.");
            push.Send("Ваш заказ доставлен.");
            Console.ReadKey();
        }
    }
}
