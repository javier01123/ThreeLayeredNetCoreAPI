using DemoAPI.BLL.Common;
using DemoAPI.BLL.Common.Exceptions;
using DemoAPI.BLL.Extensions.ContextExtensions;
using DemoAPI.DAL;
using DemoAPI.DAL.Enums;
using DemoAPI.DAL.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAPI.BLL.Services.Users.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCmd,RegisterUserRes>
    {
        readonly DemoAPIContext _ctx;
        readonly PasswordHasher<string> _hasher;

        public RegisterUserHandler(DemoAPIContext ctx)
        {
            _ctx = ctx;
            _hasher = new PasswordHasher<string>();
        }
        public async Task<RegisterUserRes> Handle(RegisterUserCmd request, CancellationToken cancellationToken)
        {
            if (_ctx.Users.IsUsernameTaken(request.Username))
                throw new BadRequestEx(new DetailedResponse("username", "username already taken"));

            var user = new User()
            {
                Username = request.Username,
                Password = _hasher.HashPassword(request.Username, request.Password),
                UserType = UserType.Normal
            };

            _ctx.Add(user);
            await _ctx.SaveChangesAsync();
            return new RegisterUserRes(user.UserId,user.Username);
        }
    }
}
