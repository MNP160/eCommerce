using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Interfaces
{
    public interface IImageWriter
    {
        Task<List<string>> UploadImage(IFormFile file);

    }
}
