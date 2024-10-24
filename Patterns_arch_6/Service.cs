using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Patterns_arch_6
{
    public class Service
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public int Duration { get; set; }  // Duration in minutes
        public double Price { get; set; }

        public Service(int serviceID, string serviceName, int duration, double price)
        {
            ServiceID = serviceID;
            ServiceName = serviceName;
            Duration = duration;
            Price = price;
        }

        
    }

    
}

