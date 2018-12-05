using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Common
{
    public class ErrorDetails
    {
        public string AccountNumber { get; set; }

        private bool Successful { get; set; }

        private decimal? Balance { get; set; }

        private string Currency { get; set; }

        private string Message { get; set; }

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
