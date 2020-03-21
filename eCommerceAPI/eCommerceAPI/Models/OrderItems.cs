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
    public class OrderItems :IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        

        [ForeignKey("Product")]
        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }

        [ForeignKey("Order")]
        public int? OrderId { get; set; }

        public virtual Orders Order { get; set; }
    }
}
