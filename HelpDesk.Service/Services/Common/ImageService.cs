using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Service.Services.Common
{
    public class ImageService : IImageService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        //Hello Ahmed
        public ImageService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<string> SaveFile(IFormFile file,string FolderName)
        {
            string fileName = null;
            if (file != null && file.Length > 0)
            {
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, FolderName);
                    fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
            }
            return fileName;
        }

    }
}
