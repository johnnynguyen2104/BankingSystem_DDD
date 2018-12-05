using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Application.BankAccounts.Models
{
    public class InquiryViewModel
    {
        public string AccountNumber { get; set; }

        public bool Successful { get; set; }

        public decimal Balance { get; set; }

        public string Currency { get; set; }

        public string Message { get; set; }

        public InquiryViewModel()
        {
            Successful = true;
            Message = "Success";
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
