using System;
using System.Collections.Generic;

namespace Library.Entity
{
    public partial class User
    {
        public User()
        {
            Address = new HashSet<Address>();
            Subscripton = new HashSet<Subscripton>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Subscripton> Subscripton { get; set; }
    }
}
