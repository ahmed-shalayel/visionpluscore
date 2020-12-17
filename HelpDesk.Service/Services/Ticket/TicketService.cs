using AutoMapper;
using HelpDesk.Data;
using HelpDesk.Data.Dto;
using HelpDesk.Data.Enums;
using HelpDesk.Data.Model;
using HelpDesk.Data.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelpDesk.Service.Services.Ticket
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _Db;
        private readonly IMapper _mapper;

        public TicketService(ApplicationDbContext Db, IMapper mapper)
        {
            _Db = Db;
            _mapper = mapper;
        }


        public PagingViewModel GetAll(int page,string name,TicketStatus? status,int? departmentId)
        {
            var totalCount = _Db.Tickets.Include(x => x.FromUser).Count(x => !x.IsDelete && (x.DepartmentId == departmentId || departmentId == null) && (x.FromUser.FirstName.Contains(name) || String.IsNullOrEmpty(name)) && (x.TicketStatus == status || status == null));
            var dataPerPage = 10.0;
            var numberOfPages = Math.Ceiling(totalCount / dataPerPage);

            if(page < 1 || page > numberOfPages)
            {
                page = 1;
            }

            var skipValue = (page - 1) * dataPerPage;


            var data = _Db.Tickets.Include(x => x.FromUser).Include(x => x.Department)
                .Where(x => !x.IsDelete && (x.DepartmentId == departmentId || departmentId == null) && (x.FromUser.FirstName.Contains(name) || String.IsNullOrEmpty(name)) && (x.TicketStatus == status || status == null))
                .OrderByDescending(x => x.CreatedAt)
                .Skip((int)skipValue).Take((int)dataPerPage).ToList();


            var tickets = _mapper.Map<List<HelpDesk.Data.Model.Ticket>, List<TicketViewModel>>(data);

            var result = new PagingViewModel();
            result.Data = tickets;
            result.NumberOfPages = (int)numberOfPages;
            result.CurrentPage = page;

            return result;
        }


        public List<TimeLineViewModel> TimeLine(int ticketId)
        {
            var timeLine = _Db.TicketTimeLines.Where(x => x.TicketId == ticketId).ToList();
            var vm = _mapper.Map<List<TicketTimeLine>, List<TimeLineViewModel>>(timeLine);
            return vm;
        }

        public void Create(TicketDto dto)
        {
            var ticket =  _mapper.Map<TicketDto, HelpDesk.Data.Model.Ticket>(dto);
            ticket.TicketStatus = TicketStatus.Pending;
            _Db.Tickets.Add(ticket);
            _Db.SaveChanges();
        }

        public void Edit(TicketDto dto)
        {
            var ticket = _Db.Tickets.SingleOrDefault(x => x.Id == dto.Id.Value && !x.IsDelete);
            var updatedTicket = _mapper.Map<TicketDto, HelpDesk.Data.Model.Ticket>(dto,ticket);
            _Db.Tickets.Update(ticket);
            _Db.SaveChanges();
        }
        public void Delete(int id)
        {
            var ticket = _Db.Tickets.SingleOrDefault(x => !x.IsDelete && x.Id == id);
            ticket.IsDelete = true;
            _Db.Tickets.Update(ticket);
            _Db.SaveChanges();
        }

        public TicketDto Get(int id)
        {
            var ticket = _Db.Tickets.SingleOrDefault(x => !x.IsDelete && x.Id == id);
            var ticketDto = _mapper.Map<HelpDesk.Data.Model.Ticket,TicketDto> (ticket);
            return ticketDto;
        }
    }
}
