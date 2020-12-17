using HelpDesk.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Data.ViewModel
{
    public class TimeLineViewModel
    {

        public int Id { get; set; }

        public int TicketId { get; set; }
       
        public TicketStatus Old { get; set; }

        public TicketStatus New { get; set; }

        public DateTime ChangeAt { get; set; }

     
    }
}
