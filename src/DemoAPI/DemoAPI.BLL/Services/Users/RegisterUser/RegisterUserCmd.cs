using FluentValidation;
using MediatR;

namespace DemoAPI.BLL.Services.Users.RegisterUser
{
    public class RegisterUserCmd : IRequest<RegisterUserRes>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RegisterUserValidator : AbstractValidator<RegisterUserCmd>
    {
        public RegisterUserValidator()
        {
            RuleFor(m => m.Username).NotEmpty()
                                    .MaximumLength(20);

            RuleFor(m => m.Password).NotEmpty()
                                    .MaximumLength(30);
        }
    }
}
