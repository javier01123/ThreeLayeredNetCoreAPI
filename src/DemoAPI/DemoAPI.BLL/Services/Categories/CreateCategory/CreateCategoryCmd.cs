using FluentValidation;
using MediatR;

namespace DemoAPI.BLL.Services.Categories.CreateCategory
{
    public class CreateCategoryCmd : IRequest<CreateCategoryRes>
    {
        public string Name { get; set; }
    }

    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCmd>
    {
        public CreateCategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty()
                                .MaximumLength(20);
        }
    }
}
