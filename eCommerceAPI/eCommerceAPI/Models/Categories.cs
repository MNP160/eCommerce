using eCommerceAPI.Interfaces;
using farmersAPi.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Models
{
    public class Categories 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CategoryId")]
        public int Id { get; set; }
       
        public string Name { get; set; }
       

        public virtual ICollection<Products> Products { get; set; }
       
    }
}
