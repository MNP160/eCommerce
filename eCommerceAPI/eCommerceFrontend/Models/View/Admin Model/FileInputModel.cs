using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.View.Admin_Model
{
    public class FileInputModel
    {
        public string Name { get; set; }
        public IFormFile FileToUpload { get; set; }
    }
}
