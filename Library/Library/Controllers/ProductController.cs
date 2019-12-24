using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class ProductController : Controller
    {
        

        public ProductController(LibraryContext libraryContext)
        {

        }
        public IActionResult Index(int id)
        {
            return View();
        }
    }
}