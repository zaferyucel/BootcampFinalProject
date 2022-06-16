using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Features.Queries.OfferQueries.GetAllOffers
{
    public class GetAllOffersQueryRequest : IRequest<List<GetAllOffersQueryResponse>>
    {

    }
}
