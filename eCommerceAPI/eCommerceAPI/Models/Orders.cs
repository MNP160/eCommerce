﻿using farmersAPi.Interfaces;
using farmersAPi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceAPI.Models
{
    public class Orders : IEntity
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public double TotalAmount { get; set; }


        [ForeignKey("User")]
        public int? UserId { get; set; }


        public virtual Users User { get; set; }

        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
