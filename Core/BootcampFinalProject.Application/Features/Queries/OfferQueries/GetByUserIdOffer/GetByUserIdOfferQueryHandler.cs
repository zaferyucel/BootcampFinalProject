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

namespace BootcampFinalProject.Application.Features.Queries.OfferQueries.GetByUserIdOffer
{
    public class GetByUserIdOfferQueryHandler : IRequestHandler<GetByUserIdOfferQueryRequest, IEnumerable<GetByUserIdOfferQueryResponse>>
    {
        private readonly IOfferReadRepository _offerReadRepository;
        private readonly IMapper _mapper;

        public GetByUserIdOfferQueryHandler(IOfferReadRepository offerReadRepository, IMapper mapper)
        {
            _offerReadRepository = offerReadRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetByUserIdOfferQueryResponse>> Handle(GetByUserIdOfferQueryRequest request, CancellationToken cancellationToken)
        {
            var o = await _offerReadRepository.GetByIdAsync(request.Id);

            IQueryable<Offer> query = _offerReadRepository.Table;
            query = query.Where(c => c.UserId.ToString() == request.Id);

            var searchedList = await query.ToListAsync();
            var a = _mapper.Map<IEnumerable<GetByUserIdOfferQueryResponse>>(searchedList);
            return a;
        }

    }
}
