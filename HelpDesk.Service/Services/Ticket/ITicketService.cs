using HelpDesk.Data.Dto;
using HelpDesk.Data.Enums;
using HelpDesk.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Service.Services.Ticket
{
    public interface ITicketService
    {
        TicketDto Get(int id);
        void Edit(TicketDto dto);
        PagingViewModel GetAll(int page, string name, TicketStatus? status, int? departmentId);

        void Create(TicketDto dto);

        void Delete(int id);

        List<TimeLineViewModel> TimeLine(int ticketId);

    }
}
