using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class ProductEditModel
    {
        public List<SelectModel> Publisher { get; set; } = new List<SelectModel>();
        public List<SelectModel> Author { get; set; } = new List<SelectModel>();
        public List<SelectModel> Category { get; set; } = new List<SelectModel>();
        public List<SelectModel> Type { get; set; } = new List<SelectModel>();
        public Product Product { get; set; }

    }
    public class SelectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
