using System;

namespace PrimeLoadBalancer.Model
{
    public class ResponseBodyPrimeNumber
    {
        public string ConnString { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string TimeUsed { get; set; }
        public bool Result { get; set; }
    }
}
