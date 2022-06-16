using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Features.Queries.OfferQueries.GetByProductIdOffer
{
    public class GetByProductIdOfferQueryRequest : IRequest<IEnumerable<GetByProductIdOfferQueryResponse>>
    {
        public string Id { get; set; }
    }
}
