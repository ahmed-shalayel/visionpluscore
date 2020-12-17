using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Service.Services.Common
{
    public interface IImageService
    {
        Task<string> SaveFile(IFormFile file, string FolderName);
    }
}
