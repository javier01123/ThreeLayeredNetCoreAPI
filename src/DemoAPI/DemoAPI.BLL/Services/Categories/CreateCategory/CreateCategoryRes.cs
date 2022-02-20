using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.BLL.Services.Categories.CreateCategory
{
    public class CreateCategoryRes
    {
        public CreateCategoryRes(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
    }
}
