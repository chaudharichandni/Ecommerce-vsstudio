using System;
using System.Collections.Generic;

namespace Ecommerce.Models.DB
{
    public partial class Brand
    {
        public int Id { get; set; }
               
        public string? Name { get; set; }
        public string? Logo { get; set; }
    }
}
