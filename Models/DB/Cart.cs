using System;
using System.Collections.Generic;

namespace Ecommerce.Models.DB
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public int? Qty { get; set; }
        public double? Rate { get; set; }
        public double? Amount { get; set; }
    }
}
