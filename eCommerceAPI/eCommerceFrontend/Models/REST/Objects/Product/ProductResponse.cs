using eCommerceFrontend.Models.REST.Objects.Cathegory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Objects
{
    public class ProductResponse
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        
        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        #nullable enable
        public string? ImagePath { get; set; }
        #nullable disable

        [Required]
        [DataType(DataType.Currency)]
        public int Price { get; set; }

    }
}
