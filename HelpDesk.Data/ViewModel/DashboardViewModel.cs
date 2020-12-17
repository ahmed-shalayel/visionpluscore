using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Data.ViewModel
{
    public class DashboardViewModel
    {
        public int numberOfUser { get; set; }

        public int numberOfDepartment { get; set; }

        public int numberOfTickets { get; set; }

        public int numberOfNewTickets { get; set; }
    }
}
