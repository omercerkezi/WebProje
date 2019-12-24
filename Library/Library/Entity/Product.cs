using System;
using System.Collections.Generic;

namespace Library.Entity
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int TypeId { get; set; }
        public int PublisherId { get; set; }
        public int AuthorId { get; set; }
        public DateTime PublishDate { get; set; }
        public string PosterUrl { get; set; }
        public bool Status { get; set; }
        public decimal Price { get; set; }
        public int PageSize { get; set; }
        public string Description { get; set; }

        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual Type Type { get; set; }
    }
}
