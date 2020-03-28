﻿using farmersAPi.DTOs;
using farmersAPi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceAPI.DTOs
{
    public class OrderDetailsDto 
    {
        public string DetailName { get; set; }
        public double DetailPrice { get; set; }
        
        public string DetailSKU { get; set; }

        public int DetailQuantity { get; set; }
        public string Size { get; set; }
        public string ImagePath { get; set; }
    }
}
