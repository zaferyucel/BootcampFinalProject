using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Features.Queries.CategoryQueries.GetByIdCategory
{
    public class GetByIdCategoryQueryRequest : IRequest<GetByIdCategoryQueryResponse>
    {
        public string Id { get; set; }
    }

}
