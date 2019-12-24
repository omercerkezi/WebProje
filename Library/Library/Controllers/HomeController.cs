using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Library.Models;
using Library.Entity;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    // Scaffold-DbContext -Connection "data source=ENESZEREN;initial catalog=Library;User Id=sa;Password=Enes.Zeren;MultipleActiveResultSets=True;App=EntityFramework" -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir "Entity/" -Context "Library" –Force
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        LibraryContext _context;

        public HomeController(ILogger<HomeController> logger,LibraryContext libraryContext)
        {
            _logger = logger;
            _context = libraryContext;
        }

        public IActionResult Index()
        {
            List<Product> productList = _context.Product.Include(i => i.Author).Include(i => i.Publisher).Take(20).ToList();
            return View(productList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
