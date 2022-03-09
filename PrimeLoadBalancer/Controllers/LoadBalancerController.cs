using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeLoadBalancer.Service;
using System.Net.Http;
using System.Threading.Tasks;

namespace PrimeLoadBalancer.Controllers
{

    public class LoadBalancerController : Controller
    {
        private readonly LoadBalancerService _loadBalancerService;

        public LoadBalancerController(LoadBalancerService loadBalancerService)
        {
            _loadBalancerService = loadBalancerService;
        }

        // POST: LoadBalancerController/Create
        [HttpPost("IsPrime")]
        public ActionResult<HttpResponseMessage> IsPrime(string primeNumber)
        {
            var result = _loadBalancerService.IsPrime(primeNumber);
            
            return Ok(result);
        }

        // POST: LoadBalancerController/Create
        [HttpPost("CountPrimes")]
        public ActionResult<HttpResponseMessage> CountPrimes(string startNumber, string endNumber)
        {
            var result = _loadBalancerService.CountPrimes(startNumber, endNumber);

            return Ok(result);
        }
    }
}
