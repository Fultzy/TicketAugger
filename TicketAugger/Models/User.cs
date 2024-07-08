using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAugger.Models
{
    internal class User
    {
        public int ID { get; set; }
        public int ExtensionNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Ticket> Tickets { get; set; }

        public User(int id, string username, string password)
        {
            ID = id;
            Username = username;
            Password = password;
        }
    }
}
