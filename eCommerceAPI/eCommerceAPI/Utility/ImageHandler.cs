using farmersAPi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Utility
{
    public class ImageHandler :IImageHandler
    {

        private readonly IImageWriter _imageWriter;

        public ImageHandler(IImageWriter imageWriter)
        {
            _imageWriter = imageWriter;
        }

        public async Task<string> UploadImage(IFormFile file)
        {
            var result = await _imageWriter.UploadImage(file);
            return result;
        }

    }
}
