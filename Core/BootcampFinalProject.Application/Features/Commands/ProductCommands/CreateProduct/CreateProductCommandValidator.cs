using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Features.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Product Name can not be larger than 100 character");
            RuleFor(x => x.Description).NotEmpty().WithMessage("ProductDescription is required");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Product Description can not be larger than 500 character");
        }
    }
}
