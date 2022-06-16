using BootcampFinalProject.Application.Repositories.OfferRepository;
using BootcampFinalProject.Domain.Entities;
using BootcampFinalProject.Persistence.Contexts;
using BootcampFinalProject.Persistence.Repositories.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Persistence.Repositories.OfferRepository
{
    public class OfferReadRepository : ReadRepository<Offer>, IOfferReadRepository
    {
        public OfferReadRepository(FinalProjectDbContext context) : base(context)
        {
        }
    }
}
