using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Common
{
    public class ErrorDetails
    {
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("successful")]
        public bool Successful { get;}

        [JsonProperty("balance")]
        public decimal? Balance { get; }

        [JsonProperty("currency")]
        public string Currency { get; }

        [JsonProperty("message")]
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
