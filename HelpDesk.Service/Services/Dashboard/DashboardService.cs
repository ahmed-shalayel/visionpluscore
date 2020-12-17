using HelpDesk.Data;
using HelpDesk.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelpDesk.Service.Services.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext _Db;
   
        public DashboardService(ApplicationDbContext Db)
        {
            _Db = Db;
        }

        public DashboardViewModel GetDashboard()
        {
            var numberOfUser = _Db.Users.Count(x => !x.IsDelete);
            var numberOfDepartment = _Db.Departments.Count(x => !x.IsDelete);
            var numberOfTickets = _Db.Tickets.Count(x => !x.IsDelete);
            var numberOfNewTickets = _Db.Tickets.Count(x => !x.IsDelete && x.CreatedAt == DateTime.Now.Date);

            var result = new DashboardViewModel();
            result.numberOfDepartment = numberOfDepartment;
            result.numberOfTickets = numberOfTickets;
            result.numberOfUser = numberOfUser;
            result.numberOfNewTickets = numberOfNewTickets;

            return result;

        }
    }
}
