using farmersAPi.Interfaces;
using farmersAPi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static farmersAPi.Models.Users;

namespace farmersAPi.DTOs
{
    public class UserDto :IDto
    {
        public int Id { get; set; }

        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ZipCode { get; set; }
        public int TransactionCount { get; set; }
        public string State { get; set; }
        public string Account { get; set; }
     

        public List<ProductDto> products { get; set; }
     

    }
}
