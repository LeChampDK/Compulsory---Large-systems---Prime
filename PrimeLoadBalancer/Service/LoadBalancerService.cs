using System;
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

        public async Task<string> IsPrime(PrimeNumberDTO primeNumber)
        {
            var connString = giveMeConfig();
            connString = connString + "IsItPrime/";
            var request = new StringContent(JsonConvert.SerializeObject(primeNumber), Encoding.UTF8, "application/json");
            //var request = new StringContent(primeNumber.ToString());
            var response = await httpClient.PostAsync(connString, request);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<string>(responseContent);

            //return responseContent;
            return result;
        }

        public Task<HttpResponseMessage> CountPrimes(string startPrime, string endPrime)
        {
            var connString = giveMeConfig();
            connString = connString + "CountPrimes/";
            var prebody = new
            {
                startPrime = startPrime,
                endPrime = endPrime
            };
            var body = JsonConvert.SerializeObject(prebody);
            var request = new StringContent(body, Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(connString, request);

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
