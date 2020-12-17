using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Data.Model
{
    public class TicketFiles
    {
        public int Id { get; set; }

        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public string FilePath { get; set; }
    }
}
