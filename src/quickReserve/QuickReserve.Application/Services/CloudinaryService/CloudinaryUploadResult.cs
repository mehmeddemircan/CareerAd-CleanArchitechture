using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Services.CloudinaryService
{
    public class CloudinaryUploadResult
    {
        public string PublicId { get; set; }
        public Uri SecureUrl { get; set; }
    }

}
