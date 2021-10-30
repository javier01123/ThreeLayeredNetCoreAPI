using DemoAPI.BLL.Services.Categories.CreateCategory;
using DemoAPI.BLL.Services.Categories.GetCategories;
using DemoAPI.Web.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Web.Controllers
{ 
    public class CategoriesController : BaseController
    {
        public CategoriesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCmd cmd)
        {
            await _mediator.Send(cmd);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var res = await _mediator.Send(new GetCategoriesCmd());
            return Ok(res);
        }
    }
}
