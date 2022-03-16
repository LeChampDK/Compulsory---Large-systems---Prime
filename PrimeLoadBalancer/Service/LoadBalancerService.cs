using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PrimeLoadBalancer.Model;

namespace PrimeLoadBalancer.Service
{
    public class LoadBalancerService
    {
        private readonly ConfigService _config;
        private readonly HttpClient httpClient;
        private int switcharoo = 1;

        public LoadBalancerService(ConfigService config)
        {
            _config = config;
            httpClient = new HttpClient();
        }

        public async Task<ResponseBodyPrimeNumber> IsPrime(PrimeNumberDTO primeNumber)
        {
            var startTime = DateTime.Now;

            var connString = giveMeConfig();
            connString = connString + "IsItPrime/";
            var request = new StringContent(JsonConvert.SerializeObject(primeNumber), Encoding.UTF8, "application/json");
            //var request = new StringContent(primeNumber.ToString());
            var response = await httpClient.PostAsync(connString, request);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(responseContent);

            var endTime = DateTime.Now;
            var timespan = endTime - startTime;

            var resultbody = new ResponseBodyPrimeNumber()
            {
                ConnString = connString,
                StartTime = startTime,
                EndTime = endTime,
                TimeUsed = timespan.ToString(@"hh\:mm\:ss\:fff"),
                Result = result
            };

            return resultbody;
        }

        public async Task<ResponseBodyPrimeNumbers> CountPrimes(PrimeNumbersDTO primeNumbers)
        {
            var startTime = DateTime.Now;

            var connString = giveMeConfig();
            connString = connString + "CountPrimes/";
            var request = new StringContent(JsonConvert.SerializeObject(primeNumbers), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(connString, request);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<string>>(responseContent);

            var endTime = DateTime.Now;
            var timespan = endTime - startTime;

            var resultbody = new ResponseBodyPrimeNumbers()
            {
                ConnString = connString,
                StartTime = startTime,
                EndTime = endTime,
                TimeUsed = timespan.ToString(@"hh\:mm\:ss\:fff"),
                Result = result.ToArray()
            };

            return resultbody;
        }

        private string giveMeConfig()
        {
            var connString = _config.APIReference1[switcharoo - 1];

            if (switcharoo == _config.APIReference1.Length){
                switcharoo = 1;
            }
            else
            {
                switcharoo++;  
            }

            return connString;
        }
    }
}
