using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Objects.Cathegory
{
    public class CathegoryResponse
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        #nullable enable
        public List<ProductResponse>? Products {get; set;}
        #nullable disable
    }
}
