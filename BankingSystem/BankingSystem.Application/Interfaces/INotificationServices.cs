using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Application.Interfaces
{
    public interface INotificationServices
    {
        Task SendNotification();
    }
}
