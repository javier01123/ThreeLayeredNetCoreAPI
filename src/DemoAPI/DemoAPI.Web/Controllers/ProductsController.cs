using DemoAPI.BLL.Services.Products.UpdateProduct;
using DemoAPI.Web.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DemoAPI.Web.Controllers
{
    public class ProductsController : BaseController
    {
        public ProductsController(IMediator mediator) : base(mediator)
        {
        }


        [HttpPut]
        [Route("{productId}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int productId, [FromBody] UpdateProductCmd cmd)
        {
            cmd.ProductId = productId;
            await _mediator.Send(cmd);
            return Ok();
        }
    }
}
