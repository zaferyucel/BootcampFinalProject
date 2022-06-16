using AutoMapper;
using BootcampFinalProject.Application.Repositories.OfferRepository;
using BootcampFinalProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Features.Queries.OfferQueries.GetByProductIdOffer
{
    public class GetByProductIdOfferQueryHandler : IRequestHandler<GetByProductIdOfferQueryRequest, IEnumerable<GetByProductIdOfferQueryResponse>>
                                                 
    {
        private readonly IOfferReadRepository _offerReadRepository;
        private readonly IMapper _mapper;

        public GetByProductIdOfferQueryHandler(IOfferReadRepository offerReadRepository, IMapper mapper)
        {
            _offerReadRepository = offerReadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetByProductIdOfferQueryResponse>> Handle(GetByProductIdOfferQueryRequest request, CancellationToken cancellationToken)
        {
          

            IQueryable<Offer> query = _offerReadRepository.Table;
            query = query.Where(c => c.ProductId.ToString() == request.Id);
            
            var searchedList = await query.ToListAsync();
            var a = _mapper.Map<IEnumerable<GetByProductIdOfferQueryResponse>>(searchedList);
            return a;
            
        }
    }
}
