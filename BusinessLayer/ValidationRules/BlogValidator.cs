using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("You cannot leave the blog title blank.");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("You cannot leave the blog content blank");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("You cannot leave the blog image blank");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Please enter less than 150 characters.");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Please enter more than 4 characters.");
        }
    }
}
