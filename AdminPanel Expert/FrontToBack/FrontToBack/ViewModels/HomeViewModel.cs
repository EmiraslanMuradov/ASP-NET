using FrontToBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.ViewModels
{
    public class HomeViewModel
    {
        public Slider Slider { get; set; }

        public List<SliderImage> SliderImage { get; set; }

        public List<Category> Category { get; set; }

        public List<Product> Product { get; set; }

        public ExpertText  ExpertText { get; set; }

        public List<Expert> Expert { get; set; }
    }
}
