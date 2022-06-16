using AutoMapper;
using BootcampFinalProject.Application.Repositories.OfferRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Features.Queries.OfferQueries.GetAllOffers
{
    public class GetAllOffersQueryHandler
    {
        private readonly IOfferReadRepository _offerReadRepository;
        private readonly IMapper _mapper;

        public GetAllOffersQueryHandler(IOfferReadRepository offerReadRepository, IMapper mapper)
        {
            _offerReadRepository = offerReadRepository;
            _mapper = mapper;
        }

        
        public async Task<List<GetAllOffersQueryResponse>> Handle(GetAllOffersQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await _offerReadRepository.GetAll().ToListAsync();

            return _mapper.Map<List<GetAllOffersQueryResponse>>(categories);
        }
    }
}
