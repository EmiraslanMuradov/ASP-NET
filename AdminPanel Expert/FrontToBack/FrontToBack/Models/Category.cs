using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bosh qoyula bilmez!")][StringLength(50, ErrorMessage = "50 simvoldan chox ola bilmez!")]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "200 simvoldan chox ola bilmez!")]
        public string Description { get; set; }

        public ICollection<Product> Poducts { get; set; }
    }
}
