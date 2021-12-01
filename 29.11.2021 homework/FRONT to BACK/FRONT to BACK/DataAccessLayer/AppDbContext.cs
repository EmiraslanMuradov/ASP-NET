using FRONT_to_BACK.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRONT_to_BACK.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Slider> Sliders { get; set; }

        public DbSet<SliderImage> SliderImages { get; set; }

        public DbSet<Catagory> Catagories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Video> Videos { get; set; }

        public DbSet<About> Abouts { get; set; }

        public DbSet<AboutItem> AboutItems { get; set; }

        public DbSet<Subscribe> Subscribes { get; set; }
    }
}
