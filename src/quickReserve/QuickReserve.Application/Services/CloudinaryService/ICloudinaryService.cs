using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Services.CloudinaryService
{
    public interface ICloudinaryService
    {
        Task<string> UploadImageWithStringAsync(string imagePath);

        Task<UploadResult> UploadImageAsync(IFormFile file);

        Task<CloudinaryUploadResult> UploadPdfToCloudinaryAsync(IFormFile file);
    }
}
