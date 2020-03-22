using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Objects
{
    public class UserRequest
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string PasswordSalt { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
