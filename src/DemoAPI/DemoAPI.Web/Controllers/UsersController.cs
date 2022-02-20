using DemoAPI.BLL.Services.Users.RegisterUser;
using DemoAPI.Web.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DemoAPI.Web.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCmd cmd)
        {    
            return Ok(await _mediator.Send(cmd));
        }
    }
}
