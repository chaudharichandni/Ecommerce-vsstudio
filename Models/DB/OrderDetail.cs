using System;
using System.Collections.Generic;

namespace Ecommerce.Models.DB
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Qty { get; set; }
        public double? Rate { get; set; }
        public double? Amount { get; set; }
    }
}
