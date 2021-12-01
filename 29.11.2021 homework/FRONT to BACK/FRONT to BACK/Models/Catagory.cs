using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRONT_to_BACK.Models
{
    public class Catagory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
