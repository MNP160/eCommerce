﻿using eCommerceFrontend.Models.REST.Objects.Cathegory;
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
        public int Discount { get; set; }

        public int SCount { get; set; } = 0;
        public int MCount { get; set; } = 0;
        public int LCount { get; set; } = 0;
        public int XLCount { get; set; } = 0;


#nullable enable
        public string? ImagePath { get; set; }
        #nullable disable

        [Required]
        [DataType(DataType.Currency)]
        public int Price { get; set; }

    }
}