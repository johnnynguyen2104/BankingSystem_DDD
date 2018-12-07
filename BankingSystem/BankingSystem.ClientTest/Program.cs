using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BankingSystem.ClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("1.Balance");
                Console.WriteLine("2.Deposit");
                Console.WriteLine("3.Withdraw");
                Console.WriteLine("4.Test Concurrency (This client will request 3 withdraw and 3 deposit request async-ly)");
                Console.WriteLine("5.Clear");

                var input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Console.WriteLine("Please input your Account Number.");
                        var accountNumber = int.Parse(Console.ReadLine());
                        var task = GetApi("api/account/balance/" + accountNumber);
                        task.Wait();
                        Console.WriteLine(task.Result);
                        break;
                    case 2:
                        Console.WriteLine("Please Input data follow this pattern: {accountnumber}/{Amount}/{Currency}, 12/100.00/THB");
                        var data = Console.ReadLine().Split('/');
                        RequestInfo postData = new RequestInfo() { AccountNumber = int.Parse(data[0]), Amount = decimal.Parse(data[1]), Currency = data[2] };
                        var taskD = CallPostApi("api/account/deposit", postData);
                        taskD.Wait();
                        Console.WriteLine(taskD.Result);
                        break;
                    case 3:
                        Console.WriteLine("Please Input data follow this pattern: {accountnumber}/{Amount}/{Currency}, 12/100.00/THB");
                        var dataW = Console.ReadLine().Split('/');
                        RequestInfo postDataW = new RequestInfo() { AccountNumber = int.Parse(dataW[0]), Amount = decimal.Parse(dataW[1]), Currency = dataW[2] };
                        var taskW = CallPostApi("api/Account/withdraw", postDataW);
                        taskW.Wait();
                        Console.WriteLine(taskW.Result);
                        break;
                    case 4:
                        RequestInfo concurrencyRq = new RequestInfo() { AccountNumber = 1, Amount = 1m, Currency = "THB" };


                        var cb = GetApi("api/account/balance/1");
                        cb.Wait();
                        Console.WriteLine("Current balance before test : " + cb.Result);

                        for (int i = 0; i < 3; i++)
                        {
                            var task2 = CallPostApi("api/Account/deposit", concurrencyRq, "D");
                            var task1 = CallPostApi("api/Account/withdraw", concurrencyRq, "W");
                        }
                        break;
                    case 5:
                        Console.Clear();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Do you want to start over ? Y/N");
            } while (Console.ReadLine().ToUpper() == "Y");
        }

        public async static Task<string> GetApi(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:63698/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                ResponseAccountInfo result = new ResponseAccountInfo();
                HttpResponseMessage response = await client.GetAsync(url);
                //return Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseAccountInfo>(response.Content.ReadAsStringAsync().Result);

                return response.Content.ReadAsStringAsync().Result;
            }
        }

        public async static Task<string> CallPostApi(string url, object jsonRequest, string prefix = "")
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:63698/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.PostAsJsonAsync(url, jsonRequest);

                var result = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(prefix))
                {
                    Console.WriteLine($"{prefix}---{result}");
                    Console.WriteLine("----------------------");
                }
             
                //return Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseAccountInfo>(response.Content.ReadAsStringAsync().Result);
                return result;
            }
        }
    }

    public class RequestInfo
    {
        public int AccountNumber { get; set; }

        public string Currency { get; set; }

        public decimal Amount { get; set; }
    }

    public class ResponseAccountInfo
    {
        public int AccountId { get; set; }

        public int AccountNumber { get; set; }

        public bool Sucessful { get; }

        public decimal Balance { get; set; }

        public string Currency { get; set; }

        public string Message { get; set; }
    }
}
