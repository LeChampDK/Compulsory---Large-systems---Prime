using System;
using System.Collections.Generic;

namespace PrimeLoadBalancer.Model
{
    public class ResponseBodyPrimeNumbers
    {
        public string ConnString { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string TimeUsed { get; set; }
        public string[] Result { get; set; }
    }
}
