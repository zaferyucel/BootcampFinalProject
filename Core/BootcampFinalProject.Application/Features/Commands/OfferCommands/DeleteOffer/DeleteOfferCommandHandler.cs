using AutoMapper;
using BootcampFinalProject.Application.Constants;
using BootcampFinalProject.Application.Repositories.OfferRepository;
using BootcampFinalProject.Application.Repositories.ProductRepository;
using BootcampFinalProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Features.Commands.OfferCommands.DeleteOffer
{
    public class DeleteOfferCommandHandler : IRequestHandler<DeleteOfferCommandRequest, DeleteOfferCommandResponse>
    {
        private readonly IOfferWriteRepository _offerWriteRepository;
        private readonly IOfferReadRepository _offerReadRepository;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IMapper _mapper;
        public DeleteOfferCommandHandler(IOfferWriteRepository offerWriteRepository, IOfferReadRepository offerReadRepository,
            IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IMapper mapper)
        {
            _offerReadRepository = offerReadRepository;
            _offerWriteRepository = offerWriteRepository;
            _productReadRepository = productReadRepository;
            _mapper = mapper;
        }


        public async Task<DeleteOfferCommandResponse> Handle(DeleteOfferCommandRequest request, CancellationToken cancellationToken)
        {
            var offeredProduct = await _productReadRepository.GetSingleAsync(p => p.Id == request.ProductId);
            if (offeredProduct is null)
            {
                return new DeleteOfferCommandResponse()
                {
                    Success = false,
                    Message = Messages.ProductDoesNotExist
                };
            }
            else
            {
                IQueryable<Offer> query = _offerReadRepository.Table;

                query = query.Where(o => o.ProductId == request.ProductId);
                query = query.Where(o => o.UserId == request.UserId);

                if (query.FirstOrDefault() != null)
                {
                    int deletedOfferId = (int)query.First().Id;

                    var offer = await _offerReadRepository.GetByIdAsync(deletedOfferId.ToString());
                    _offerWriteRepository.Remove(offer);
                    await _offerWriteRepository.SaveAsync();

                    return new DeleteOfferCommandResponse()
                    {
                        Success = true,
                        Message = Messages.OfferDeleted
                    };
                }
                else
                {
                    return new DeleteOfferCommandResponse()
                    {
                        Success = false,
                        Message = Messages.ProductDoesNotExist
                    };
                }
                

            }



        }
    }
}
