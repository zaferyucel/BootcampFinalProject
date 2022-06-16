using AutoMapper;
using BootcampFinalProject.Application.Repositories.ProductRepository;
using BootcampFinalProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Features.Queries.ProductQueries.SearchProduct
{
    public class SearchProductQueryHandler : IRequestHandler<SearchProductQueryRequest, IEnumerable<SearchProductQueryResponse>>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IMapper _mapper;

        public SearchProductQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
        {
            _productReadRepository = productReadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SearchProductQueryResponse>> Handle(SearchProductQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Product> query = _productReadRepository.Table;

            if (!string.IsNullOrEmpty(request.Name))
            {
                query = query.Where(c => c.Name.ToLower().Contains(request.Name.ToLower()));
            }

            if (!string.IsNullOrEmpty(request.Description))
            {
                query = query.Where(c => c.Description.ToLower().Contains(request.Description.ToLower()));
            }

            if (!string.IsNullOrEmpty(request.CategoryName))
            {
                query = query.Where(c => c.Category.Name.ToLower().Contains(request.CategoryName.ToLower()));
            }

            if (request.MinPrice>0 || request.MaxPrice>0)
            {
                if (request.MinPrice > 0 && request.MaxPrice > 0)
                {
                    query = query.Where(c => c.Price > request.MinPrice);
                    query = query.Where(c => c.Price < request.MaxPrice);
                }
                else if (request.MinPrice > 0)
                {
                    query = query.Where(c => c.Price > request.MinPrice);
                }
                else
                {
                    query = query.Where(c => c.Price < request.MaxPrice);
                }
            }

            

            

            var searchedList = await query.ToListAsync();
            var a = _mapper.Map<IEnumerable<SearchProductQueryResponse>>(searchedList);

            return a;
        }
    }
}
