using FRONT_to_BACK.DataAccessLayer;
using FRONT_to_BACK.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRONT_to_BACK.Controllers
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
            var sliderImages = _dbContext.SliderImages.ToList();
            var slider = _dbContext.Sliders.SingleOrDefault();
            var categories = _dbContext.Catagories.ToList();
            var products = _dbContext.Products.Include(x => x.Catagory).ToList();
            var about = _dbContext.Abouts.SingleOrDefault();
            var aboutItems = _dbContext.AboutItems.ToList();
            var video = _dbContext.Videos.SingleOrDefault();
            var subscribe = _dbContext.Subscribes.SingleOrDefault();

            return View(new HomeViewModel 
            {
                Slider = slider,
                SliderImages = sliderImages,
                Catagories = categories,
                Products = products,
                About = about,
                AboutItems = aboutItems,
                Video = video,
                Subscribe = subscribe
            });
        }
    }
}
