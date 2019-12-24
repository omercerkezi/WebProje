using System;
using System.Collections.Generic;

namespace Library.Entity
{
    public partial class ContactForm
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
