using System;
using System.Collections.Generic;

namespace Library.Entity
{
    public partial class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool Status { get; set; }
    }
}
