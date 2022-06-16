using BootcampFinalProject.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Domain.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }


        // => Bir kategori birçok ürüne sahip olabilir.
        public ICollection<Product> Products { get; set; }
    }
}
