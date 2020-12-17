using HelpDesk.Service.Services.Dashboard;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Web.Controllers
{
  
    public class DashboardController : Controller
    {


        private readonly IDashboardService _dashboardService;
  

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }


        
        public IActionResult Index()
        {
            var data = _dashboardService.GetDashboard();
            return View(data);
        }
    }
}
