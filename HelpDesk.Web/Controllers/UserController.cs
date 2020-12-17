using HelpDesk.Data.Dto;
using HelpDesk.Service;
using HelpDesk.Service.Services.Department;
using HelpDesk.Web.Constant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Web.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserService _userService;
        private readonly IDepartmentService _deaprtmentService;
        private readonly IToastNotification _toastNotification;
        public UserController(IToastNotification toastNotification,IDepartmentService deaprtmentService,IUserService userService)
        {
            _userService = userService;
            _deaprtmentService = deaprtmentService;
            _toastNotification = toastNotification;
        }

        public IActionResult Index()
        {
            var data = _userService.GetAll();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var departments = _deaprtmentService.GetAll();
            ViewData["departments"] = new SelectList(departments, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDto dto) {

            var data = await _userService.Create(dto);
            _toastNotification.AddSuccessToastMessage(Messages.Add);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string Id)
        {
            var user = _userService.Get(Id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(UserDto dto)
        {
             _userService.Update(dto);
            _toastNotification.AddSuccessToastMessage(Messages.Edit);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {
             _userService.Delete(id);
            _toastNotification.AddSuccessToastMessage(Messages.Delete);
            return RedirectToAction("Index");
        }

    }
}
