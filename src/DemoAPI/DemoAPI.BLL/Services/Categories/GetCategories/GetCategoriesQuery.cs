using MediatR;
using System.Collections.Generic;

namespace DemoAPI.BLL.Services.Categories.GetCategories
{
    public class GetCategoriesQuery : IRequest<IEnumerable<CategoriySelectDto>>
    {
    }
}
