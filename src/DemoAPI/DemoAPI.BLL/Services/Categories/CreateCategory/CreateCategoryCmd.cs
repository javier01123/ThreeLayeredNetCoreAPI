using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.BLL.Services.Categories.CreateCategory
{
    public class CreateCategoryCmd:IRequest
    {
        public string Name { get; set; }
    }

    public class CreateCategoryValidator:AbstractValidator<CreateCategoryCmd>
    {
        public CreateCategoryValidator()
        {
            RuleFor(c => c.Name).MaximumLength(20);
        }
    }
}
