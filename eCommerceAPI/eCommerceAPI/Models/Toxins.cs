
using farmersAPi.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static farmersAPi.Models.Toxins;

namespace farmersAPi.Models
{
    public class Toxins :IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
       public string Description { get; set; }
       public ToxinTypes Type { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public enum ToxinTypes
        {
            Type1,
            Type2,
            Type3

        }


    }
}
