using DemoAPI.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAPI.BLL.Services.Categories.GetCategories
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoriySelectDto>>
    {
        DemoAPIContext _ctx;

        public GetCategoriesHandler(DemoAPIContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<CategoriySelectDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _ctx.Categories.Select(c =>
                                            new CategoriySelectDto()
                                            {
                                                CategoryId = c.CategoryId,
                                                Name = c.Name
                                            }).ToListAsync();
        }
    }
}
