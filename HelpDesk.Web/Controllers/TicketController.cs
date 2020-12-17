using HelpDesk.Data.Dto;
using HelpDesk.Data.Enums;
using HelpDesk.Service;
using HelpDesk.Service.Services.Department;
using HelpDesk.Service.Services.Ticket;
using HelpDesk.Service.Services.TicketFiles;
using HelpDesk.Web.Constant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Web.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly ITicketFileService _ticketFileService;
        private readonly IDepartmentService _departmentService;
        private readonly IToastNotification _toastNotification;
        private readonly IUserService _userService;

        public TicketController(ITicketFileService ticketFileService,IToastNotification toastNotification,ITicketService ticketService,IDepartmentService departmentService, IUserService userService)
        {
            _ticketService = ticketService;
            _toastNotification = toastNotification;
            _departmentService = departmentService;
            _userService = userService;
            _ticketFileService = ticketFileService;
        }

        public IActionResult Index(int pageNumber,string name,TicketStatus? status,int? departmentId)
        {
            var result = _ticketService.GetAll(pageNumber,name,status, departmentId);
            ViewData["departemnts"] = new SelectList(_departmentService.GetAll(), "Id", "Name");
            ViewBag.searchName = name;
            return View(result);
        }

        [HttpGet]
        public IActionResult GetFile(int Id) {
            var data = _ticketFileService.GetFiles(Id);


            return View(data);
        }

        [HttpGet]
        public IActionResult AddFile(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile file,int Id)
        {
            await _ticketFileService.SaveTicketFile(Id,file);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Create()
        {
            ViewData["users"] = new SelectList(_userService.GetAll(), "Id", "FullName");
            ViewData["departemnts"] = new SelectList(_departmentService.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(TicketDto model)
        {
            _ticketService.Create(model);
            _toastNotification.AddSuccessToastMessage(Messages.Add);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var ticket = _ticketService.Get(id);
            ViewData["users"] = new SelectList(_userService.GetAll(), "Id", "FullName");
            ViewData["departemnts"] = new SelectList(_departmentService.GetAll(), "Id", "Name");
            return View(ticket);
        }

        [HttpPost]
        public IActionResult Edit(TicketDto model)
        {
            _ticketService.Edit(model);
            _toastNotification.AddSuccessToastMessage(Messages.Add);
            return RedirectToAction("Index");
        }

        public IActionResult GetTimeLine(int id)
        {
            var timeLines = _ticketService.TimeLine(id);
            return View(timeLines);
        }

        public IActionResult Delete(int id)
        {
            _ticketService.Delete(id);
            _toastNotification.AddSuccessToastMessage(Messages.Delete);
            return RedirectToAction("Index");
        }

    }
}
