using HelpDesk.Data.Enums;
using HelpDesk.Data.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Service.Services.TicketFiles
{
    public interface ITicketFileService
    {
        List<TicketFilesViewModel> GetFiles(int ticketId);

        Task SaveTicketFile(int ticketId, IFormFile file);

    }
}
