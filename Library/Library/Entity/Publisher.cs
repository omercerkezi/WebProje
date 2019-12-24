using System;
using System.Collections.Generic;

namespace Library.Entity
{
    public partial class Publisher
    {
        public Publisher()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
