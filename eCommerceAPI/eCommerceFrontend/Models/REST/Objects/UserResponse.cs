using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Objects
{
    public class UserResponse
    {
        public int id { get; set; }
        public string email { get; set; }
        public string passwordHash { get; set; }
        public string passwordSalt { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string role { get; set; }
    }
}
