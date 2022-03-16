using Microsoft.AspNetCore.Mvc;
using PrimeAPI_2.Model;
using PrimeAPI_2.Service;
using System.Net.Http;

namespace PrimeAPI_2.Controllers
{
    [ApiController]
    [Route("PrimeCalc2")]
    public class PrimeController : Controller
    {
        private readonly PrimeService _primeService;

        public PrimeController(PrimeService primeService)
        {
            _primeService = primeService;
        }

        [HttpPost("IsItPrime")]
        public ActionResult<HttpResponseMessage> IsItPrime([FromBody] PrimeNumber primeNumber)
        {
            var result = _primeService.IsPrime(primeNumber.Number);

            return Ok(result);
        }

        [HttpPost("CountPrimes")]
        public ActionResult<HttpResponseMessage> CountPrimes([FromBody] PrimeNumbers primeNumbers)
        {
            var startNumber = primeNumbers.StartNumber;
            var endNumber = primeNumbers.EndNumber;
            var result = _primeService.CountPrimes(startNumber, endNumber);

            return Ok(result);
        }
    }
}
