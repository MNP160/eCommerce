using farmersAPi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Models
{
    public class Entity : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
