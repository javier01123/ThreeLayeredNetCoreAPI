using DemoAPI.DAL;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAPI.BLL.Services.Categories.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCmd, UpdateCategoryRes>
    {
        readonly DemoAPIContext _ctx;

        public UpdateCategoryHandler(DemoAPIContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<UpdateCategoryRes> Handle(UpdateCategoryCmd request, CancellationToken cancellationToken)
        {
            var category = await _ctx.Categories.FindAsync(request.CategoryId);
            category.Name = request.Name;
            await _ctx.SaveChangesAsync();
            return new UpdateCategoryRes(category.CategoryId, category.Name);
        }
    }
}
