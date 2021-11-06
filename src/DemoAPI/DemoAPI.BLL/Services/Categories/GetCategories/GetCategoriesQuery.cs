using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.BLL.Services.Categories.GetCategories
{
    public class GetCategoriesQuery:IRequest<IEnumerable<CategoriySelectDto>>
    {
    }
}
