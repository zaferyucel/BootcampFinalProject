using BootcampFinalProject.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Domain.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; } 
        public int Price { get; set; }
        public bool IsOfferable { get; set; }
        public bool IsSold { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public ICollection<Offer>? Offers { get; set; }

    }
}
