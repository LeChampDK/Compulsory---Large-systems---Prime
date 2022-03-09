using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PrimeLoadBalancer.Service
{
    public class LoadBalancerService
    {
        private readonly Config _config;
        private readonly HttpClient httpClient;
        private int switcharoo = 1;

        public LoadBalancerService(Config config)
        {
            _config = config;
            httpClient = new HttpClient();
        }

        public Task<HttpResponseMessage> IsPrime(string primeNumber)
        {
            var connString = giveMeConfig();
            var body = JsonConvert.SerializeObject(primeNumber);
            var request = new StringContent(body, Encoding.UTF8, "application/json") ;
            var result = httpClient.PostAsync(connString, request);
            
            return result;
        }

        public Task<HttpResponseMessage> CountPrimes(string startPrime, string endPrime)
        {
            var connString = giveMeConfig();
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
