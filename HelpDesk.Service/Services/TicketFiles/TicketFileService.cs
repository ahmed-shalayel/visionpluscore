using AutoMapper;
using HelpDesk.Data;
using HelpDesk.Data.Model;
using HelpDesk.Data.ViewModel;
using HelpDesk.Service.Services.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Service.Services.TicketFiles
{
    public class TicketFileService : ITicketFileService
    {
        private readonly ApplicationDbContext _DB;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;
        public TicketFileService(IImageService imageService,IMapper mapper,ApplicationDbContext DB)
        {
            _DB = DB;
            _imageService = imageService;
            _mapper = mapper;
        }


        public List<TicketFilesViewModel> GetFiles(int ticketId)
        {
            var files = _DB.TicketFiles.Where(x => x.TicketId == ticketId).ToList();
            var filesVM = _mapper.Map<List<Data.Model.TicketFiles>, List<TicketFilesViewModel>>(files);
            return filesVM;
        }


        public async Task SaveTicketFile(int ticketId,IFormFile file)
        {
            string fileName = await _imageService.SaveFile(file, "TicketFiles");

            var ticketFile = new Data.Model.TicketFiles()
            {
                TicketId = ticketId,
                FilePath = fileName
            };

            _DB.TicketFiles.Add(ticketFile);
            _DB.SaveChanges();
        }

    }
}
