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
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _deaprtmentService;
        private readonly IUserService _userService;
        private readonly IToastNotification _toastNotification;

      

        public DepartmentController(IToastNotification toastNotification,IDepartmentService deaprtmentService, IUserService userService)
        {
            _deaprtmentService = deaprtmentService;
            _userService = userService;
            _toastNotification = toastNotification;
        }

        public IActionResult Index()
        {
            var data = _deaprtmentService.GetAll();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var users = _userService.GetAll();
            ViewData["admins"] = new SelectList(users, "Id","FullName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentDto dto)
        {
            _deaprtmentService.Save(dto);
            _toastNotification.AddSuccessToastMessage(Messages.Add);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _deaprtmentService.Get(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(DepartmentDto dto)
        {
            _deaprtmentService.Save(dto);
            _toastNotification.AddSuccessToastMessage(Messages.Edit);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _deaprtmentService.Delete(id);
            _toastNotification.AddSuccessToastMessage(Messages.Delete);
            return RedirectToAction("Index");
        }


    }
}
