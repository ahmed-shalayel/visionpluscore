using HelpDesk.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Data.ViewModel
{
    public class TicketViewModel
    {
        public int Id { get; set; }
  
        public DateTime CreatedAt { get; set; }

        public DepartmentViewModel Department { get; set; }
       
        public string Title { get; set; }

        public TicketStatus TicketStatus { get; set; }

        public UserViewModel FromUser { get; set; }
    }
}
