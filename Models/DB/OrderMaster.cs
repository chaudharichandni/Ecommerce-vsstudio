using System;
using System.Collections.Generic;

namespace Ecommerce.Models.DB
{
    public partial class OrderMaster
    {
        public int Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? UserId { get; set; }
        public double? OrderAmount { get; set; }
    }
}
