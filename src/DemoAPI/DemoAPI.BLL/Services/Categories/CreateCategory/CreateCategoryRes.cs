using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.BLL.Services.Categories.CreateCategory
{
    public class CreateCategoryRes
    {
        public CreateCategoryRes(int categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
        }
        public int CategoryId { get; private set; }
        public string Name { get; private set; }
    }
}
