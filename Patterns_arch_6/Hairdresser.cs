using System;
using System.Collections.Generic;


namespace Patterns_arch_6
{
    public class Hairdresser
    {
        public int HairdresserID { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public Schedule Schedule { get; set; }

        public Hairdresser(int hairdresserID, string name, string specialization)
        {
            HairdresserID = hairdresserID;
            Name = name;
            Specialization = specialization;
        }

        public List<Booking> ManageBookings()
        {
            return Schedule.ViewSchedule();
        }

        public void ViewSchedule()
        {
            Schedule.DisplaySchedule();
        }

    }
}

