using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeAPI_1.Model;
using PrimeLoadBalancer.Service;
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
        public ActionResult<HttpResponseMessage> IsPrime(PrimeNumberDTO primeNumber)
        {
            var result = _loadBalancerService.IsPrime(primeNumber.Number);
            
            return Ok(result);
        }

        // POST: LoadBalancerController/Create
        [HttpPost("CountPrimes")]
        public ActionResult<HttpResponseMessage> CountPrimes([FromBody] PrimeNumbersDTO primeNumber)
        {
            var startNumber = primeNumber.StartNumber;
            var endNumber = primeNumber.EndNumber; 
            var result = _loadBalancerService.CountPrimes(startNumber, endNumber);

            return Ok(result);
        }
    }
}
