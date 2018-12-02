using System;

namespace BankingSystem.Common
{
    public interface IDatetime
    {
        DateTime Now { get; }

        DateTime UtcNow { get; }
    }
}
