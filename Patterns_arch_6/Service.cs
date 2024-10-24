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

        //public static List<Service> ViewServices()
        //{
            
        //    return new List<Service>
        //    {
        //    new Service(1, "Haircut", 30, 15.0),
        //    new Service(2, "Hair Coloring", 90, 50.0),
        //    new Service(3, "Hair Styling", 45, 25.0)
        //    };
        //}
    }

    
}

