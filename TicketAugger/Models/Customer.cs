using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAugger.Models
{
    internal class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public Customer(int id, string name, string email, string phone, string address, string city, string state, string zip)
        {
            ID = id;
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
        }
    }
}
