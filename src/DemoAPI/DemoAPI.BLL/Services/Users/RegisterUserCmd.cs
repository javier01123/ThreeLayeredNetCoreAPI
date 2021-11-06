using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.BLL.Services.Users
{
    public class RegisterUserCmd:IRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RegisterUserValidator : AbstractValidator<RegisterUserCmd>
    {
        public RegisterUserValidator()
        {
            RuleFor(m => m.Username).NotEmpty();
            RuleFor(m => m.Username).MaximumLength(20);
            RuleFor(m => m.Password).NotEmpty();
            RuleFor(m => m.Password).MaximumLength(30);
        }
    }
}
