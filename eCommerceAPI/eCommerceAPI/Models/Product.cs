using farmersAPi.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Models
{
    public class Product :IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.ImageUrl)]
        public string ImagePath { get; set; }
        public int Price { get; set; }
        [ForeignKey("Cathegory")]
        public int? CathegoryId { get; set; }
        public virtual Cathegory Cathegory { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        public virtual Users User { get; set; }

        public virtual ICollection<Toxins> Toxins { get; set; }

        //public int UserId{get; set;}     //need to decide where user stuff will be
        //public User User{get; set;}


    }
}
