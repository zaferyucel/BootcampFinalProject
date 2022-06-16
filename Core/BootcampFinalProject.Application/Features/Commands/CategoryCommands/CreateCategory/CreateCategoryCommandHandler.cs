using AutoMapper;
using BootcampFinalProject.Application.Constants;
using BootcampFinalProject.Application.Repositories.CategoryRepository;
using BootcampFinalProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Features.Commands.CategoryCommands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly IMapper _mapper;


        public CreateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository, IMapper mapper)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _categoryReadRepository = categoryReadRepository;
            _mapper = mapper;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map <Category>(request);        
            var result = await _categoryWriteRepository.AddAsync(category);

            _ = _categoryWriteRepository.SaveAsync();
            return new CreateCategoryCommandResponse() { Succes = result, Message = result ? Messages.CategoryAdded : Messages.CategoryAddedError };
        }
    }
}
