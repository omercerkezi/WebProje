using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Library.Entity;
using Library.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class AdminController : Controller
    {
        LibraryContext _contextLibrary;
        public AdminController(LibraryContext libraryContext)
        {
            _contextLibrary = libraryContext;
        }

        public IActionResult Login(string email, string password)
        {
            if (email != "sefa@gmail.com")
            {
                return View();
            }
            User user = _contextLibrary.User.Where(w => w.Email == email && w.Password == password).FirstOrDefault();
            if (user == null)
            {
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("FullName", user.Fullname),
                new Claim(ClaimTypes.Role, "User"),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,

                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),

                IsPersistent = true,
            };

            HttpContext.SignInAsync(
               CookieAuthenticationDefaults.AuthenticationScheme,
               new ClaimsPrincipal(claimsIdentity),
               authProperties);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult EditProduct(int id)
        {
            if (User.Identity.Name.ToString() != "sefa@gmail.com")
            {
                return RedirectToAction("Index", "Home");
            }
            ProductEditModel result = new ProductEditModel();
            result.Author = _contextLibrary.Author.Select(s => new SelectModel { Id = s.Id, Name = s.Fullname }).ToList();
            result.Category = _contextLibrary.Category.Select(s => new SelectModel { Id = s.Id, Name = s.Name }).ToList();
            result.Type = _contextLibrary.Type.Select(s => new SelectModel { Id = s.Id, Name = s.Name }).ToList();
            result.Publisher = _contextLibrary.Publisher.Select(s => new SelectModel { Id = s.Id, Name = s.Name }).ToList();
            result.Product = _contextLibrary.Product.Where(w => w.Id == id).FirstOrDefault();
            return View(result);
        }
        public ActionResult UpdateProduct(Product model)
        {
            if (User.Identity.Name.ToString() != "sefa@gmail.com")
            {
                return RedirectToAction("Index", "Home");
            }
            Product current = _contextLibrary.Product.Where(w => w.Id == model.Id).FirstOrDefault();
            if (current == null)
            {
                return RedirectToAction("Index", "Home");
            }
            current.Name = model.Name;
            current.AuthorId = model.AuthorId;
            current.PublisherId = model.PublisherId;
            current.CategoryId = model.CategoryId;
            current.TypeId = model.TypeId;
            current.PosterUrl = model.PosterUrl;
            current.Price = model.Price;
            current.PageSize = model.PageSize;
            current.Description = model.Description;

            _contextLibrary.SaveChanges();


            return RedirectToAction("Products", "Admin");
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            if (User.Identity.Name.ToString() != "sefa@gmail.com")
            {
                return RedirectToAction("Index", "Home");
            }
            ProductEditModel result = new ProductEditModel();
            result.Author = _contextLibrary.Author.Select(s => new SelectModel { Id = s.Id, Name = s.Fullname }).ToList();
            result.Category = _contextLibrary.Category.Select(s => new SelectModel { Id = s.Id, Name = s.Name }).ToList();
            result.Type = _contextLibrary.Type.Select(s => new SelectModel { Id = s.Id, Name = s.Name }).ToList();
            result.Publisher = _contextLibrary.Publisher.Select(s => new SelectModel { Id = s.Id, Name = s.Name }).ToList();

            return View(result);
        }

        [HttpPost]
        public ActionResult CreateProduct(Product model)
        {
            if (User.Identity.Name.ToString() != "sefa@gmail.com")
            {
                return RedirectToAction("Index", "Home");
            }
            Product current = new Product();
            current.Name = model.Name;
            current.AuthorId = model.AuthorId;
            current.PublisherId = model.PublisherId;
            current.CategoryId = model.CategoryId;
            current.TypeId = model.TypeId;
            current.PosterUrl = model.PosterUrl;
            current.Price = model.Price;
            current.PageSize = model.PageSize;
            current.Description = model.Description;
            current.PublishDate = DateTime.Now;
            current.Status = true;

            _contextLibrary.Product.Add(current);
            _contextLibrary.SaveChanges();
            return RedirectToAction("Products", "Admin");
        }

        public IActionResult Products()
        {
            if (User.Identity.Name.ToString() != "sefa@gmail.com")
            {
                return RedirectToAction("Index", "Home");
            }
            List<Product> productList = _contextLibrary.Product.Include(i => i.Author).Include(i => i.Publisher).Take(20).ToList();
            return View(productList);
        }
    }
}