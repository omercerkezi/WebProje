using System;
using System.Collections.Generic;

namespace Library.Entity
{
    public partial class SiteSetting
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string Address { get; set; }
    }
}
