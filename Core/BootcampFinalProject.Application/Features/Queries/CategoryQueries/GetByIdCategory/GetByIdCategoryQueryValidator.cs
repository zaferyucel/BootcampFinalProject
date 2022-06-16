using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Features.Queries.CategoryQueries.GetByIdCategory
{
    public class GetByIdCategoryQueryValidaor : AbstractValidator<GetByIdCategoryQueryRequest>
    {
        public GetByIdCategoryQueryValidaor()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");

                //.GreaterThan(0).WithMessage("Please Enter Integer");

        }
    }
}
