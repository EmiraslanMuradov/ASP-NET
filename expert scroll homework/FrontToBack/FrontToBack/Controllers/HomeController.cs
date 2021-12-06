using FrontToBack.DataAccessLayer;
using FrontToBack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var slider = _dbContext.Sliders.SingleOrDefault();
            var sliderImages = _dbContext.SliderImages.ToList();
            var category = _dbContext.Categories.ToList();
            var product = _dbContext.Products.Include(x => x.Category).ToList();
            var expertText = _dbContext.ExpertTexts.SingleOrDefault();
            var experts = _dbContext.Experts.ToList();

            return View(new HomeViewModel { 
                Slider = slider,
                SliderImage = sliderImages,
                Product = product,
                Category = category,
                ExpertText = expertText,
                Expert = experts
            });
        }
    }
}
