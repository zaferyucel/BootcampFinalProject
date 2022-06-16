﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Features.Queries.ProductQueries.SearchProduct
{
    public class SearchProductQueryRequest : IRequest<IEnumerable<SearchProductQueryResponse>>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public string? CategoryName { get; set; }
        
    }
}
