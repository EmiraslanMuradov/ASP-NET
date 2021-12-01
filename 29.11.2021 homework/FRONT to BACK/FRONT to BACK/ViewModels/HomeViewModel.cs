using FRONT_to_BACK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRONT_to_BACK.ViewModels
{
    public class HomeViewModel
    {
        public Slider Slider { get; set; }

        public List<SliderImage> SliderImages { get; set; }

        public List<Catagory> Catagories { get; set; }

        public List<Product> Products { get; set; }

        public About About { get; set; }

        public Video Video { get; set; }

        public List<AboutItem> AboutItems { get; set; }

        public Subscribe Subscribe { get; set; }
    }
}
