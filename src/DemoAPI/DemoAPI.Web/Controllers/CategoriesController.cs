using DemoAPI.BLL.Services.Categories.CreateCategory;
using DemoAPI.BLL.Services.Categories.GetCategories;
using DemoAPI.BLL.Services.Categories.UpdateCategory;
using DemoAPI.Web.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DemoAPI.Web.Controllers
{
    public class CategoriesController : BaseController
    {
        public CategoriesController(IMediator mediator) : base(mediator)
        {
        }

       

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {     
            return Ok(await _mediator.Send(new GetCategoriesQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCmd cmd)
        {
            return Ok(await _mediator.Send(cmd));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCmd cmd)
        {
            return Ok(await _mediator.Send(cmd));
        }
    }
}
