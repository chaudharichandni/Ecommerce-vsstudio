﻿using System;
using System.Collections.Generic;

namespace Ecommerce.Models.DB
{
    public partial class Product
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public double? Mrp { get; set; }
        public double? Rate { get; set; }
    }
}
