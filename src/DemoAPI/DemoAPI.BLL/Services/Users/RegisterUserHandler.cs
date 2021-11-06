using DemoAPI.DAL;
using DemoAPI.DAL.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAPI.BLL.Services.Users
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCmd>
    {
        DemoAPIContext _ctx;
        public RegisterUserHandler(DemoAPIContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Unit> Handle(RegisterUserCmd request, CancellationToken cancellationToken)
        {            
            var hasher = new PasswordHasher<string>();
            var user = new User()
            {
                Username = request.Username,
                Password = hasher.HashPassword(request.Username, request.Password)
            };

            _ctx.Add(user);
            await _ctx.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
