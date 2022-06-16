using BootcampFinalProject.Application.Constants;
using BootcampFinalProject.Application.Repositories.CategoryRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Features.Commands.CategoryCommands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {


        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly ICategoryWriteRepository _categoryWriteRepository;


        public UpdateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryReadRepository.GetByIdAsync(request.Id.ToString());
            if (category == null)
            {
                return new UpdateCategoryCommandResponse
                {
                    Success = false,
                    Message = Messages.CategoryNotFound
                };
            }
            
            category.Name = request.Name?? category.Name;
            category.Description = request.Description?? category.Description;
            category.Id = request.Id;   
            _categoryWriteRepository.Update(category);
            await _categoryWriteRepository.SaveAsync();

            return new UpdateCategoryCommandResponse
            {
                Success = true,
                Message = Messages.CategoryUpdated
            };
        }
    }
}
