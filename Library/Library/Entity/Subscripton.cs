using System;
using System.Collections.Generic;

namespace Library.Entity
{
    public partial class Subscripton
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; }
        public DateTime SubscriptionDate { get; set; }

        public virtual User User { get; set; }
    }
}
