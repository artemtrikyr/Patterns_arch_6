using System;
using System.Collections.Generic;

namespace Patterns_arch_6
{
    public class Schedule
    {
        public int ScheduleID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public Hairdresser Hairdresser { get; set; }
        public bool Availability { get; set; }

        private List<Booking> Bookings = new List<Booking>();

        public Schedule(int scheduleID, DateTime date, TimeSpan time, Hairdresser hairdresser)
        {
            ScheduleID = scheduleID;
            Date = date;
            Time = time;
            Hairdresser = hairdresser;
            Availability = true;
        }

        public List<Booking> ViewSchedule()
        {
            return Bookings;
        }

        public void CheckAvailability(Hairdresser hairdresser, DateTime date, TimeSpan time)
        {
            foreach (var booking in Bookings)
            {
                if (booking.Hairdresser == hairdresser && booking.Date == date && booking.Time == time)
                {
                    Availability = false;
                    break;
                }
            }
        }

        public void UpdateSchedule(int scheduleID, DateTime newDate, TimeSpan newTime)
        {
            if (ScheduleID == scheduleID)
            {
                Date = newDate;
                Time = newTime;
            }
        }

        public void DisplaySchedule()
        {
            Console.WriteLine($"Schedule for {Hairdresser.Name}: {Date.ToShortDateString()} at {Time}");
        }
    }
}

