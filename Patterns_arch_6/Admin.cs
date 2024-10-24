using System;
using System.Collections.Generic;

namespace Patterns_arch_6
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public Admin(int adminID, string name, string email, string phone, string password)
        {
            AdminID = adminID;
            Name = name;
            Email = email;
            Phone = phone;
            Password = password;
        }

        public bool Login(string email, string password)
        {
            // Hardcoded for example purposes
            return Email == email && Password == password;
        }

        public List<Booking> ManageBookings(List<Booking> bookings)
        {
            return bookings;
        }

        public List<Client> ManageClients(List<Client> clients)
        {
            return clients;
        }

        public List<Hairdresser> ManageHairdressers(List<Hairdresser> hairdressers)
        {
            return hairdressers;
        }

        public List<Service> ManageServices(List<Service> services)
        {
            return services;
        }

       
    }
}

