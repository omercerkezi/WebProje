using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class ProductController : Controller
    {

        LibraryContext _contextLibrary;

        public ProductController(LibraryContext libraryContext)
        {
            _contextLibrary = libraryContext;
        }
        public IActionResult Index(int id)
        {
            Product product = _contextLibrary.Product.Include(i => i.Author).Include(i => i.Publisher).Where(w => w.Id == id).FirstOrDefault();
            return View(product);
        }

        public IActionResult Magazines()
        {
            List<Product> productList = _contextLibrary.Product.Include(i => i.Author).Include(i => i.Publisher).Where(w=>w.TypeId==2).Take(20).ToList();
            return View(productList);
        }

    }
}