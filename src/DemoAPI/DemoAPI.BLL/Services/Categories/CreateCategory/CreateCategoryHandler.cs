using DemoAPI.DAL;
using DemoAPI.DAL.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAPI.BLL.Services.Categories.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCmd, CreateCategoryRes>
    {
        DemoAPIContext _ctx;

        public CreateCategoryHandler(DemoAPIContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<CreateCategoryRes> Handle(CreateCategoryCmd request, CancellationToken cancellationToken)
        {
            var newCategory = new Category(request.Name);
            _ctx.Add(newCategory);
            await _ctx.SaveChangesAsync();
            return new CreateCategoryRes(newCategory.CategoryId, newCategory.Name);
        }
    }
}
