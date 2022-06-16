using AutoMapper;
using BootcampFinalProject.Application.Repositories.CategoryRepository;
using BootcampFinalProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Features.Queries.CategoryQueries.SearchCategory
{
    public class SearchCategoryQueryHandler : IRequestHandler<SearchCategoryQueryRequest, IEnumerable<SearchCategoryQueryResponse>>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IMapper _mapper;

        public SearchCategoryQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
        {
            _categoryReadRepository = categoryReadRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SearchCategoryQueryResponse>> Handle(SearchCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Category> query = _categoryReadRepository.Table;

            if (!string.IsNullOrEmpty(request.Name))
            {
                query = query.Where(c => c.Name.Contains(request.Name));
            }

            if (!string.IsNullOrEmpty(request.Description))
            {
                query = query.Where(c => c.Description.Contains(request.Description));
            }

            var searchedList = await query.ToListAsync();
            var a = _mapper.Map<IEnumerable<SearchCategoryQueryResponse>>(searchedList);

            return a;
        }
    }
}

