using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Common
{
    public class ErrorDetails
    {
        public string AccountNumber { get; set; }

        public bool Successful { get;}

        public decimal? Balance { get; }

        public string Currency { get; }

        public string Message { get; set; }

        public ErrorDetails(string mess)
        {
            Successful = false;
            Balance = null;
            Currency = null;
            Message = mess;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
