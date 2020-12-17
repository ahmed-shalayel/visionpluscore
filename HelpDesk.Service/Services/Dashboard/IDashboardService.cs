using HelpDesk.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Service.Services.Dashboard
{
    public interface IDashboardService
    {
        DashboardViewModel GetDashboard();
    }
}
