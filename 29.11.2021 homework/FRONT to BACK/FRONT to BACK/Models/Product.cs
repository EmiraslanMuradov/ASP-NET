using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRONT_to_BACK.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public double Price { get; set; }

        public Catagory Catagory { get; set; }

        public int CatagoryId { get; set; }
    }
}
