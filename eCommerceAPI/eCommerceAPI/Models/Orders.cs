using farmersAPi.Interfaces;
using farmersAPi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceAPI.Models
{
    public class Orders 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("OrderId")]

        public int Id { get; set; }

        public double TotalAmount { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public string OrderEmail { get; set; }
        public string OrderZipCode { get; set; }
        public string Size { get; set; }

        [Range(1,4)]
        public int Stage { get; set; }
        public string OrderSKU { get; set; }
           


        public  virtual Users User { get; set; }

        public  virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
