using BootcampFinalProject.Application.Constants;
using BootcampFinalProject.Application.Repositories.ProductRepository;
using BootcampFinalProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Features.Commands.ProductCommands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public DeleteProductCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _productReadRepository.GetByIdAsync(request.Id);

            if (product is null)
            {
                return new DeleteProductCommandResponse
                {
                    Message = Messages.ProductDoesNotExist,
                    Succes = false
                };
            }

            _productWriteRepository.Remove(product);

            var result = await _productWriteRepository.SaveAsync() == 1 ? true : false;

            return new DeleteProductCommandResponse
            {
                Message = result == true ? Messages.ProductDelete : Messages.ProductDeleteError,
                Succes = result
            };

        }


    }
}


