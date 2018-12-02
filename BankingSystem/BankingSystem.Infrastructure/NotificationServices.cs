using BankingSystem.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace BankingSystem.Infrastructure
{
    public class NotificationServices : INotificationServices
    {
        public Task SendNotification()
        {
            return Task.CompletedTask;
        }
    }
}
