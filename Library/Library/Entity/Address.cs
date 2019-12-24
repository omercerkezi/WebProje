using System;
using System.Collections.Generic;

namespace Library.Entity
{
    public partial class Address
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
