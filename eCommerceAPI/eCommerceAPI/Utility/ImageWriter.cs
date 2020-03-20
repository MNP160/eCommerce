using farmersAPi.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Utility
{
    public class ImageWriter :IImageWriter
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ImageWriter(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<string> UploadImage(IFormFile file)
        {
            if (CheckIfImageFile(file))
            {
                return await WriteFile(file);
            }
            return "Invalid Image";
        }

        private bool CheckIfImageFile(IFormFile file)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }
            return ImageHelper.GetImageFormat(fileBytes) != ImageHelper.ImageFormats.unknown;

        }

        public async Task<string> WriteFile(IFormFile file)
        {
            string filename;
            var path = " ";
            try
            {
                var extension="."+ file.FileName.Split(".")[file.FileName.Split(".").Length - 1];
                filename = Guid.NewGuid().ToString() + extension;

                 path = Path.Combine(_hostingEnvironment.WebRootPath, "images", filename);
                using (var bits = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(bits);
                }


            }catch(Exception ex)
            {
                return ex.Message;
            }

           // var serverPath = _hostingEnvironment.WebRootPath+"\\images\\"+filename;
           // System.Diagnostics.Debug.WriteLine("--------------------------------------------------------");
            //System.Diagnostics.Debug.WriteLine(serverPath);
           // System.Diagnostics.Debug.WriteLine(_hostingEnvironment.WebRootPath+"\\images\\"+filename);
            //System.Diagnostics.Debug.WriteLine(filename);

            //System.Diagnostics.Debug.WriteLine("--------------------------------------------------------");
           // System.Diagnostics.Debug.WriteLine("--------------------------------------------------------");
           // System.Diagnostics.Debug.WriteLine("--------------------------------------------------------");
            return filename;
        }

    }
}
