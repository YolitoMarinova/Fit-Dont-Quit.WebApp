using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FitDontQuit.Services
{
    public interface ICloudinaryService
    {
        Task<string> UploadAsync(IFormFile file, string fileName);
    }
}
