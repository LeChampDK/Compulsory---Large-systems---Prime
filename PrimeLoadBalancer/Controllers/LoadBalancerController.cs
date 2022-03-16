using Microsoft.AspNetCore.Mvc;
using PrimeLoadBalancer.Model;
using PrimeLoadBalancer.Service;
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
        public async Task<ActionResult<string>> IsPrimeAsync(PrimeNumberDTO primeNumber)
        {
            var result = await _loadBalancerService.IsPrime(primeNumber);
            
            return Ok(result);
        }

        // POST: LoadBalancerController/Create
        [HttpPost("CountPrimes")]
        public async Task<ActionResult<List<string>>> CountPrimesAsync([FromBody] PrimeNumbersDTO primeNumber)
        {
            var startNumber = primeNumber.StartNumber;
            var endNumber = primeNumber.EndNumber; 
            var result = await _loadBalancerService.CountPrimes(startNumber, endNumber);

            return Ok(result);
        }
    }
}
