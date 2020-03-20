using farmersAPi.Interfaces;
using farmersAPi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace farmersAPi.Servces
{
    public class UserService :IUserService
    {
        private APIContext _context;
        public UserService(APIContext context)
        {
            _context = context;
        }

        public Users Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;


            var user = _context.Users.SingleOrDefault(x => x.Email == email);


            if (user == null)
                return null;


            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public Users Create(Users user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password is required");
            }

            if (_context.Users.Any(x => x.Email == user.Email))
            {
                throw new Exception("Username must be unique");
            }

            string passwordHash;
            byte[] passwordSalt;

            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public IEnumerable<Users> GetAll()
        {
            return _context.Users.AsEnumerable();
        }

        public Users GetById(int id)
        {
            return _context.Users.Find(id);
        }

        private static bool VerifyPasswordHash(string password, string storedHash, byte[] storedSalt)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password cannot be null");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("password cannot be empty or white space", "password");
            }

            /*   if (storedHash.Length != 64)
               {
                   throw new ArgumentException("the hash length cannot be different than 64", "storedHash");
               }

               if (storedSalt.Length != 128)
               {
                   throw new ArgumentException("the salt length cannot be different than 128", "storedSalt");
               }*/

            using (var sha256 = SHA256.Create(password))
            {
                var computedHash = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                    {

                        return false;
                    }
                }
            }

            return true;
        }

        private static void CreatePasswordHash(string password, out string passwordHash, out byte[] passwordSalt)
        {
            if (password == null)
            {

                throw new ArgumentNullException("password");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("password cannot be null or white space", "password");
            }
            var sBuilder = new StringBuilder();

            using (var sha256 = SHA256.Create())
            {

                var Hash = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < Hash.Length; i++)
                {
                    sBuilder.Append(Hash[i].ToString("x2"));
                }
                passwordHash = sBuilder.ToString();
            }
            using (var generator = RandomNumberGenerator.Create())
            {
                byte[] bytes = new byte[128 / 8];
                generator.GetBytes(bytes);
                passwordSalt = bytes;
            }


        }

        public Users Update(Users user, string password = null)
        {
            var u = _context.Users.Find(user.Id);
            if (u == null)
            {
                throw new Exception("no such user");
            }



            if (!string.IsNullOrWhiteSpace(user.Email) && user.Email != u.Email)
            {

                if (_context.Users.Any(x => x.Email == user.Email))
                    throw new Exception("Email " + user.Email + " is already taken");

                u.Email = user.Email;
            }


            if (!string.IsNullOrWhiteSpace(user.FirstName))
                u.FirstName = user.FirstName;

            if (!string.IsNullOrWhiteSpace(user.LastName))
                u.LastName = user.LastName;


            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordSalt;
                string passwordHash;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }



            u.ZipCode = user.ZipCode;


            u.Account = user.Account;
            u.State = user.State;
            //add error checking 

            _context.Users.Update(u);
           _context.SaveChangesAsync();
            return u;
        }

        public Users Delete(int Id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == Id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChangesAsync();
            }

            return user;
        }


    }
}

