using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator: AbstractValidator<Category>
    {
        public CategoryValidator() 
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("You cannot leave the category name empty.");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("You cannot leave the category description empty.");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Please enter less than 50 characters.");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Please enter more than 2 characters.");
        }

    }
}
