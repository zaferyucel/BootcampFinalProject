using BootcampFinalProject.Application.Constants;
using BootcampFinalProject.Application.Repositories.ProductRepository;
using BootcampFinalProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Features.Commands.ProductCommands.BuyProduct
{
    public class BuyProductCommandHandler : IRequestHandler<BuyProductCommandRequest, BuyProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public BuyProductCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        public async Task<BuyProductCommandResponse> Handle(BuyProductCommandRequest request, CancellationToken cancellationToken)
        {
            var p = await _productReadRepository.GetSingleAsync(p => p.Id == request.ProductId);

            if (p is null)
            {
                return new BuyProductCommandResponse()
                {
                    Success = false,
                    Message = Messages.ProductDoesNotExist
                };
            }
            else if (p.IsSold == true)
            {
                return new BuyProductCommandResponse()
                {
                    Success = false,
                    Message = Messages.ProductCanNotBeBuy
                };
            }
            else
            {
                Product product = new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                    IsOfferable = p.IsOfferable,
                    IsSold = true


                };
                _productWriteRepository.Update(product);
                await _productWriteRepository.SaveAsync();

                return new BuyProductCommandResponse()
                {
                    Success = true,
                    Message = Messages.ProductSold
                };
            }
        }
    }
}
