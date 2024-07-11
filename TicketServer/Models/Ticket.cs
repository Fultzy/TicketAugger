using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketServer.Models
{
    internal class Ticket
    {
        public int ID { get; set; }

        // Ticket Details
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }

        // Ticket Users
        public User CreatedBy { get; set; }
        public User UpdatedBy { get; set; }
        public User AssignedTo { get; set; }
    
        // Ticket Timestamps
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime ClosedOn { get; set; }

        public Ticket(int id, User createdBy, string title, string description, string status, string priority, User assignedTo, DateTime createdOn, DateTime updatedOn, DateTime closedOn)
        {
            ID = id;
            CreatedBy = createdBy;
            Title = title;
            Description = description;
            Status = status;
            Priority = priority;
            AssignedTo = assignedTo;
            CreatedOn = createdOn;
            UpdatedOn = updatedOn;
            ClosedOn = closedOn;
        }


    }
}
