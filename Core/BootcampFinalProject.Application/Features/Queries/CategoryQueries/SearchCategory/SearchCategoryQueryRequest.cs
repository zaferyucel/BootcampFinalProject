﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Features.Queries.CategoryQueries.SearchCategory
{
    public class SearchCategoryQueryRequest : IRequest<IEnumerable<SearchCategoryQueryResponse>>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
