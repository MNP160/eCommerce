using farmersAPi.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Models
{
    public class Users :IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ZipCode { get; set; }
        public int TransactionCount { get; set; }
        public Province State { get; set; }
        public AccountType Account { get; set; }
        public enum Province { Sofia, Varna, Pleven }
        public enum AccountType { Farmer, Customer, Premium }

        public virtual ICollection<Product> Products { get; set; }

    }
}
