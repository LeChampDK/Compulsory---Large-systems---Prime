using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeAPI_2.Service
{
    public class PrimeService
    {
        public bool IsPrime(string primeNumber)
        {
            var number = int.Parse(primeNumber);
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        public List<string> CountPrimes(string startNumber, string endNumber)
        {
            int number = 0;
            var start = int.Parse(startNumber);
            var end = int.Parse(endNumber);

            var result = new List<string>();

            for (int i = start; i < end; i++)
            {
                number = 0;
                if (i > 1)
                {
                    for (int j = 2; j < i; j++)
                    {
                        if (i % j == 0)
                        {
                            number = 1;
                            break;
                        }
                    }
                    if (number == 0)
                    {
                        result.Add(i.ToString());
                    }
                }
            }
            return result;
        }
    }
}
