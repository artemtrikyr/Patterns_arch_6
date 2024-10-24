using System;
using System.Collections.Generic;

namespace Patterns_arch_6
{
    public class Client
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<Booking> BookingHistory { get; set; } = new List<Booking>();

        public Client( int clientID, string name, string phone, string email)
        {
            ClientID = clientID;
            Name = name;
            Phone = phone;
            Email = email;
            BookingHistory = new List<Booking>();
        }

        public void Register(string name, string phone, string email)
        {
            Name = name;
            Phone = phone;
            Email = email;
        }

        public bool Login(string phone, string email)
        {
            return Phone == phone && Email == email;
        }

        public void CreateBooking(Booking booking)
        {
            BookingHistory.Add(booking);
        }

        public void CancelBooking(int bookingID)
        {
            var booking = BookingHistory.Find(b => b.BookingID == bookingID);
            if (booking != null)
            {
                BookingHistory.Remove(booking);
                Console.WriteLine($"Booking with ID {bookingID} has been canceled.");
            }
            else
            {
                Console.WriteLine($"Booking with ID {bookingID} not found.");
            }
        }
    }

}

