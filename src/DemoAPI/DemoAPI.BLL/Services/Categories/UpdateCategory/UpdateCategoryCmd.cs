using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.BLL.Services.Categories.UpdateCategory
{
    public class UpdateCategoryCmd:IRequest<UpdateCategoryRes>
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }

    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCmd>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty()
                                .MaximumLength(20);            
        }
    }

}
