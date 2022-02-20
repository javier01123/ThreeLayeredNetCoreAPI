using DemoAPI.BLL.Services.Categories.CreateCategory;
using DemoAPI.BLL.Services.Categories.GetCategories;
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

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCmd cmd)
        {            
            return Ok(await _mediator.Send(cmd));
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {     
            return Ok(await _mediator.Send(new GetCategoriesQuery()));
        }
    }
}
