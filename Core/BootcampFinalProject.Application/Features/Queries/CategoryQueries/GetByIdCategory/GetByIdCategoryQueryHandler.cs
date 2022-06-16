using AutoMapper;
using BootcampFinalProject.Application.Repositories.CategoryRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Features.Queries.CategoryQueries.GetByIdCategory
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, GetByIdCategoryQueryResponse>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IMapper _mapper;

        public GetByIdCategoryQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
        {
            _categoryReadRepository = categoryReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCategoryQueryResponse> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var isNumeric = int.TryParse(request.Id, out _);

            if (!isNumeric)
            {
                return new GetByIdCategoryQueryResponse()
                {
                    
                    Message = "Please Enter a Integer Value"
                };
            }

            var category = await _categoryReadRepository.GetByIdAsync(request.Id);

            return _mapper.Map<GetByIdCategoryQueryResponse>(category);
        }
    }
}



