using farmersAPi.Interfaces;
using farmersAPi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceAPI.Models
{
    public class OrderItems :IEntity
    {

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey("Product")]
        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
