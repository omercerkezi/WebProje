using System;
using System.Collections.Generic;

namespace Library.Entity
{
    public partial class Admin
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public string Phone { get; set; }
    }
}
