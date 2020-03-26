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
    public class OrderDetails 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DetailId { get; set; }
        public string DetailName { get; set; }
        public double DetailPrice { get; set; }

        
        public string DetailSKU { get; set; }
        
        public int DetailQuantity { get; set; }
                      

        public int OrderId { get; set; }
        public  virtual Orders Order { get; set; }
    }
}
