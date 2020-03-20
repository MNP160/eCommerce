using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static farmersAPi.Models.Users;


namespace farmersAPi.Utility
{
    public class RegisterModel
    {

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        public Province State { get; set; }
        [Required]
        public AccountType Account { get; set; }

    }
}
