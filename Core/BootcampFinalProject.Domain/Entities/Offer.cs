using BootcampFinalProject.Domain.Entities.Authentications;
using BootcampFinalProject.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Domain.Entities
{
    public class Offer: BaseEntity
    {
        public int OfferPrice { get; set; }

        public int ProductId { get; set; }

        public Product? Product { get; set; }

        public int UserId { get; set; }
        public AppUser? User { get; set; }


      
    }
}
