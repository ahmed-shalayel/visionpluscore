using HelpDesk.Service.Services.Role;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Web.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public IActionResult Index()
        {
            var roles =  _roleService.GetAll();
            return View(roles);
        }

        public async Task<IActionResult> InitRoleAsync()
        {
            await _roleService.InitRoles();
            return RedirectToAction("Index");
        }
    }
}
