using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Features.Queries.OfferQueries.GetByUserIdOffer
{
    public class GetByUserIdOfferQueryRequest: IRequest<IEnumerable<GetByUserIdOfferQueryResponse>>
    {
        public string Id { get; set; }
    
    }
}
