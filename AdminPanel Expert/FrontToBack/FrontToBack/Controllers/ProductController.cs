using FrontToBack.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _dbContext;

        private readonly int _productCount;

        public ProductController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _productCount = _dbContext.Products.Count();
        }

        public IActionResult Index()
        {
            var product = _dbContext.Products.Take(8).Include(x => x.Category).ToList();

            ViewBag.ProductCount = _productCount;

            return View(product);
        }

        public IActionResult Load(int skip)
        {
            var product = _dbContext.Products.Skip(skip).Take(4).Include(x => x.Category).ToList();

            return PartialView("_ProductPartial", product);
        }
    }
}
