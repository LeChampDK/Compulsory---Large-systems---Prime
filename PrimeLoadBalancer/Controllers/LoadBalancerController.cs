using Microsoft.AspNetCore.Mvc;
using PrimeLoadBalancer.Model;
using PrimeLoadBalancer.Service;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PrimeLoadBalancer.Controllers
{
    [ApiController]
    [Route("LoadBalancer")]
    public class LoadBalancerController : Controller
    {
        private readonly LoadBalancerService _loadBalancerService;

        public LoadBalancerController(LoadBalancerService loadBalancerService)
        {
            _loadBalancerService = loadBalancerService;
        }

        // POST: LoadBalancerController/Create
        [HttpPost("IsPrime")]
        public async Task<ResponseBodyPrimeNumber> IsPrimeAsync(PrimeNumberDTO primeNumber)
        {
            var result = await _loadBalancerService.IsPrime(primeNumber);
            
            return result;
        }

        // POST: LoadBalancerController/Create
        [HttpPost("CountPrimes")]
        public async Task<ResponseBodyPrimeNumbers> CountPrimesAsync([FromBody] PrimeNumbersDTO primeNumber)
        {
            var result = await _loadBalancerService.CountPrimes(primeNumber);
         
            return result;
        }
    }
}
