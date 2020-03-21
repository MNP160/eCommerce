using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Objects
{
    public class AuthenticationResponse
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
