using System;
using System.Collections.Generic;

namespace Library.Entity
{
    public partial class Order
    {
        public int D { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
    }
}
