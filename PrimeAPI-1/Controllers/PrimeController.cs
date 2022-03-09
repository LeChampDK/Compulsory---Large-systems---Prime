using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeAPI_1.Service;
using System.Net.Http;

namespace PrimeAPI_1.Controllers
{
    public class PrimeController : Controller
    {
        private readonly PrimeService _primeService;

        public PrimeController(PrimeService primeService)
        {
            _primeService = primeService;
        }

        // POST: LoadBalancerController/Create
        [HttpPost("IsItPrime")]
        public ActionResult<HttpResponseMessage> IsItPrime([FromBody]string primeNumber)
        {
            var result = _primeService.IsPrime(primeNumber);

            return Ok(result);
        }

        // POST: LoadBalancerController/Create
        [HttpPost("CountPrimes")]
        public ActionResult<HttpResponseMessage> CountPrimes(string startNumber, string endNumber)
        {
            var result = _primeService.CountPrimes(startNumber, endNumber);

            return Ok(result);
        }
    }
}
