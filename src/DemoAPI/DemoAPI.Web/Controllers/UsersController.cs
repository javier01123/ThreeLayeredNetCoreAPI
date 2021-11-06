using DemoAPI.BLL.Services.Users;
using DemoAPI.Web.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            await _mediator.Send(cmd);
            return Ok();
        }
    }
}
