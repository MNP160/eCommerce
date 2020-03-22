using eCommerceAPI.Interfaces;
using eCommerceAPI.Models;
using farmersAPi.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Models
{
    public class Product : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ProductId")]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.ImageUrl)]
        public string ImagePath { get; set; }
        public int Discount { get; set; }

        public int SCount { get; set; } = 0;
        public int MCount { get; set; } = 0;
        public int LCount { get; set; } = 0;
        public int XLCount { get; set; } = 0;

        public int Price { get; set; }
        [ForeignKey("Cathegory")]
        public int? CathegoryId { get; set; }
        public virtual Cathegory Cathegory { get; set; }

        public virtual ICollection<OrderItems> OrderItems { get; set; }

        }

       



    
}
