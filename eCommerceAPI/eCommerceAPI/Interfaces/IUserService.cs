using farmersAPi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Interfaces
{
    public interface IUserService
    {
        Users Authenticate(string email, string password);
        IEnumerable<Users> GetAll();
        Users GetById(int id);
        Users Create(Users user, string password);
        Users Update(Users user, string password);
        Users Delete(int Id);

    }
}
