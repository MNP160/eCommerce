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
    public class Products 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ProductId")]
        public int Id { get; set; }

        public string Name { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        [DataType(DataType.ImageUrl)]
        public string ImagePath { get; set; }
        public double OriginalPrice { get; set; }
        public double ActualPrice { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ProductSKU { get; set; }
        
        public bool IsLive { get; set; }

        public Dictionary<string, int> Size { get; set; } = new Dictionary<string, int>();
      
        public int CategoryId { get; set; }
        public  virtual Categories Category { get; set; }

       

        }

       



    
}
