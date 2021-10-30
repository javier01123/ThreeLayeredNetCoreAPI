using DemoAPI.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAPI.BLL.Services.Categories.GetCategories
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesCmd, IEnumerable<CategoriySelectDto>>
    {
        DemoAPIContext _ctx;

        public GetCategoriesHandler(DemoAPIContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<CategoriySelectDto>> Handle(GetCategoriesCmd request, CancellationToken cancellationToken)
        {
            var res = await _ctx.Categories.Select(c => new CategoriySelectDto()
            {
                CategoryId = c.CategoryId,
                Name = c.Name
            }).ToListAsync();

            return res;
        }
    }
}
