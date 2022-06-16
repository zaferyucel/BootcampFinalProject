using AutoMapper;
using BootcampFinalProject.Application.Constants;
using BootcampFinalProject.Application.Repositories.OfferRepository;
using BootcampFinalProject.Application.Repositories.ProductRepository;
using BootcampFinalProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Features.Commands.OfferCommands
{
    public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommandRequest, CreateOfferCommandResponse>
    {
        private readonly IOfferWriteRepository _offerWriteRepository;
        private readonly IOfferReadRepository _offerReadRepository;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IMapper _mapper;
        public CreateOfferCommandHandler(IOfferWriteRepository offerWriteRepository, IOfferReadRepository offerReadRepository,
            IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IMapper mapper)
        {
            _offerReadRepository = offerReadRepository;
            _offerWriteRepository = offerWriteRepository;
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateOfferCommandResponse> Handle(CreateOfferCommandRequest request, CancellationToken cancellationToken)
        {
            var p = await _productReadRepository.GetSingleAsync(p => p.Id == request.ProductId);

            if (p is null)
            {
                return new CreateOfferCommandResponse()
                {
                    Success = false,
                    Message = Messages.OfferCreateProductNotExist
                };
            }
            else if (p.IsOfferable == false)
            {
                return new CreateOfferCommandResponse()
                {
                    Success = false,
                    Message = Messages.OfferCreateError
                };
            }

            IQueryable<Offer> query = _offerReadRepository.Table;

            query = query.Where(o => o.ProductId == request.ProductId);
            query = query.Where(o => o.UserId == request.UserId);

            if (query.FirstOrDefault() == null)
            {
                var offer = _mapper.Map<Offer>(request);
                
                Product product = new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                    IsOfferable = p.IsOfferable,
                    IsSold = p.IsSold


                };
                var result = await _offerWriteRepository.AddAsync(offer);
                await _offerWriteRepository.SaveAsync();

                var resultProduct = _productWriteRepository.Update(product);
                await _productWriteRepository.SaveAsync();

                return new CreateOfferCommandResponse { Success = result, Message = result ? Messages.OfferCreateSuccess : Messages.OfferFail };
            }
            else
            {
                int deletedOfferId = (int)query.First().Id;

                var offer = _mapper.Map<Offer>(request);
                

                _offerWriteRepository.Update(offer);

                await _productWriteRepository.SaveAsync();
                return new CreateOfferCommandResponse { Success = true, Message = Messages.OfferUpdated};
            }


        }
    }
}
