using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Features.Queries.OfferQueries.GetAllOffers
{
    public class GetAllOffersQueryResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int OfferPrice { get; set; }
    }
}
