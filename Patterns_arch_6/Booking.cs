using System;

namespace Patterns_arch_6
{
    public class Booking
    {
        public int BookingID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public Client Client { get; set; }
        public Hairdresser Hairdresser { get; set; }
        public Service Service { get; set; }
        public string Status { get; set; }

        public Booking(int bookingID, DateTime date, TimeSpan time, Client client, Hairdresser hairdresser, Service service)
        {
            BookingID = bookingID;
            Date = date;
            Time = time;
            Client = client;
            Hairdresser = hairdresser;
            Service = service;
            Status = "Confirmed";
        }

        public void Modify(DateTime newDate, TimeSpan newTime, Service newService)
        {
            Date = newDate;
            Time = newTime;
            Service = newService;
        }

        public void Cancel()
        {
            Status = "Cancelled";
        }
    }
}

