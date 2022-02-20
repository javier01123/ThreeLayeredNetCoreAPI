using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.BLL.Services.Categories.UpdateCategory
{
    public class UpdateCategoryRes
    {
        public UpdateCategoryRes(int categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
