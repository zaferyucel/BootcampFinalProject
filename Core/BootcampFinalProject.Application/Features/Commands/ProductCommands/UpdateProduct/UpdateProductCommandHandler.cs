using BootcampFinalProject.Application.Constants;
using BootcampFinalProject.Application.Repositories.ProductRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Features.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public UpdateProductCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {

            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _productReadRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                return new UpdateProductCommandResponse
                {
                    Success = false,
                    Message = Messages.ProductDoesNotExist
                };
            }

            if (CheckRequestIsEmpty(request))
            {
                return new UpdateProductCommandResponse
                {
                    Success = false,
                    Message = Messages.RequestEmpty
                };
            }


            if (await CheckNameIsExist(request.Name))
            {
                return new UpdateProductCommandResponse
                {
                    Success = false,
                    Message = Messages.ProductNameExist
                };
            }


            product.Name = request.Name ?? product.Name;
            product.Description = request.Description ?? product.Description;
            product.Price = request.Price;
            product.CategoryId = request.CategoryId ?? product.CategoryId;
            product.IsOfferable = product.IsOfferable;
            product.IsSold = product.IsSold;
            

            _productWriteRepository.Update(product);

            await _productWriteRepository.SaveAsync();

            return new UpdateProductCommandResponse
            {
                Success = true,
                Message = Messages.ProductUpdateSuccess
            };
        }

        private async Task<bool> CheckNameIsExist(string? name)
        {
            if (name is null)
            {
                return false;
            }

            var productName = await _productReadRepository.GetSingleAsync(p => p.Name == name);
            if (productName == null)
            {
                return false;
            }

            return true;
        }

        private bool CheckRequestIsEmpty(UpdateProductCommandRequest request)
        {
            if (string.IsNullOrEmpty(request.Name)
                && string.IsNullOrEmpty(request.Description)
                && request.Price == null &&
                request.CategoryId == null
                )
            {
                return true;
            }

            return false;
        }
    }
}
