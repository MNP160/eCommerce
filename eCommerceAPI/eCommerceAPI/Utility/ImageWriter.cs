using farmersAPi.Interfaces;
using ImageMagick;
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
        private readonly IHttpContextAccessor _accessor;

        public ImageWriter(IWebHostEnvironment hostingEnvironment, IHttpContextAccessor accessor)
        {
            _hostingEnvironment = hostingEnvironment;
            _accessor = accessor;
        }
        public async Task<List<string>> UploadImage(IFormFile file)
        {
            if (CheckIfImageFile(file))
            {
                return await WriteFile(file);
            }
            return null;
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

        public async Task<List<string>> WriteFile(IFormFile file)
        {
            List<string> paths = new List<string>();
            paths.Add(CreateThumbnail(file, 350,100).Result);
            paths.Add(CreateImage(file, 1000,100).Result);

            return paths;
        }

        public async Task<string> CreateThumbnail(IFormFile file, int size, int quality)
        {
            string filename;
                  
            string thumbnailLocation;
            var thumbnailPath = " ";
          

            try
            {

                var extension = "." + file.FileName.Split(".")[file.FileName.Split(".").Length - 1];

                filename = Guid.NewGuid().ToString() + extension;
               


                thumbnailPath = Path.Combine(_hostingEnvironment.WebRootPath, "images", "thumbnails", filename);


                System.Diagnostics.Debug.WriteLine(thumbnailPath);
             

                byte[] data;
                using (var br = new BinaryReader(file.OpenReadStream()))
                    data = br.ReadBytes((int)file.OpenReadStream().Length);
                using (var image = new MagickImage(data))
                {
                    image.Resize(size,size);
                    image.Strip();
                    image.Quality = quality;
                    await Task.Run(() => image.Write(thumbnailPath));

                }


                thumbnailLocation = _accessor.HttpContext.Request.Scheme + "://" + _accessor.HttpContext.Request.Host + "/images/"+ "thumbnails/" + filename;
                System.Diagnostics.Debug.WriteLine(thumbnailLocation);

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return thumbnailLocation;

        }
      
        public async Task<string> CreateImage(IFormFile file, int size, int quality)
        {
            string filename;

            string imageLocation;
            var imagePath = " ";


            try
            {

                var extension = "." + file.FileName.Split(".")[file.FileName.Split(".").Length - 1];

                filename = Guid.NewGuid().ToString() + extension;



                imagePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", "large", filename);


                System.Diagnostics.Debug.WriteLine(imagePath);


                byte[] data;
                using (var br = new BinaryReader(file.OpenReadStream()))
                    data = br.ReadBytes((int)file.OpenReadStream().Length);
                using (var image = new MagickImage(data))
                {
                    
                    image.Strip();
                    image.Quality = quality;
                    await Task.Run(() => image.Write(imagePath));

                }


                imageLocation = _accessor.HttpContext.Request.Scheme + "://" + _accessor.HttpContext.Request.Host + "/images/"+"large/" + filename;
                System.Diagnostics.Debug.WriteLine(imageLocation);


            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return imageLocation;

        }


    }
}
