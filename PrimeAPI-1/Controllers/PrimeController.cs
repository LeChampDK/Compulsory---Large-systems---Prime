using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeAPI_1.Model;
using PrimeAPI_1.Service;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace PrimeAPI_1.Controllers
{
    [ApiController]
    [Route("PrimeCalc1")]
    public class PrimeController : Controller
    {
        private readonly PrimeService _primeService;

        public PrimeController(PrimeService primeService)
        {
            _primeService = primeService;
        }

        // POST: LoadBalancerController/Create
        [HttpPost("IsItPrime")]
        public ActionResult<bool> IsItPrime([FromBody] PrimeNumber primeNumber)
        {
            var result = _primeService.IsPrime(primeNumber.Number);

            return Ok(result);
        }

        // POST: LoadBalancerController/Create
        [HttpPost("CountPrimes")]
        public List<string> CountPrimes([FromBody] PrimeNumbers primeNumbers)
        {
            var startNumber = primeNumbers.StartNumber;
            var endNumber = primeNumbers.EndNumber;
            var result = _primeService.CountPrimes(startNumber, endNumber);

            return result;
        }
    }
}
