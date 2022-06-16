using BootcampFinalProject.Application.Constants;
using BootcampFinalProject.Application.Repositories.ProductRepository;
using BootcampFinalProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Features.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var p = await _productReadRepository.GetSingleAsync(p => p.Name == request.Name);

            if (p is not null)
            {
                return new CreateProductCommandResponse()
                {
                    Success = false,
                    Message = Messages.ProductAddedError
                };
            }


            Product product = new Product
            {
                Id = null,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                CategoryId = request.CategoryId,
                IsOfferable= true,
                IsSold = false
                
            };

            var result = await _productWriteRepository.AddAsync(product);

            await _productWriteRepository.SaveAsync();//== 1 ? true : false;

            return new CreateProductCommandResponse { Success = result, Message = result ? Messages.ProductAdded : Messages.ProductAddedFail };
        }
    }
}
