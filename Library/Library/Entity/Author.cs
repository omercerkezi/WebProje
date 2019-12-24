using System;
using System.Collections.Generic;

namespace Library.Entity
{
    public partial class Author
    {
        public Author()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
