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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.ImageUrl)]
        public string ImagePath { get; set; }
        public int Price { get; set; }
        public int CathegoryId { get; set; }
        public CathegoryResponse Cathegory { get; set; }
    }
}
