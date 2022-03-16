using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
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

        public async Task<bool> IsPrime(PrimeNumberDTO primeNumber)
        {
            var connString = giveMeConfig();
            connString = connString + "IsItPrime/";
            var request = new StringContent(JsonConvert.SerializeObject(primeNumber), Encoding.UTF8, "application/json");
            //var request = new StringContent(primeNumber.ToString());
            var response = await httpClient.PostAsync(connString, request);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(responseContent);

            //return responseContent;
            return result;
        }

        public async Task<List<string>> CountPrimes(PrimeNumbersDTO primeNumbers)
        {
            var connString = giveMeConfig();
            connString = connString + "CountPrimes/";
            var request = new StringContent(JsonConvert.SerializeObject(primeNumbers), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(connString, request);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<string>>(responseContent);

            return result;
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
