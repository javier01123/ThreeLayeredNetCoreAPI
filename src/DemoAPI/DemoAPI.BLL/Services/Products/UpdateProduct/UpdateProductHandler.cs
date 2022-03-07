using DemoAPI.BLL.Common.Exceptions;
using DemoAPI.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAPI.BLL.Services.Products.UpdateProduct
{
    internal class UpdateProductHandler : IRequestHandler<UpdateProductCmd>
    {
        readonly DemoAPIContext _ctx;

        public UpdateProductHandler(DemoAPIContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Unit> Handle(UpdateProductCmd request, CancellationToken cancellationToken)
        {
            var product = await _ctx.Products.FindAsync(request.ProductId);
            if (product == null) throw new NotFoundEx();
            product.Name = request.Name;
            product.Price = request.Price.Value;
            await _ctx.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
