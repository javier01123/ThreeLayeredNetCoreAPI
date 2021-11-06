using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.DAL.Models
{
    public class Category
    {
        private Category() { }
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public static Category FromName(string name)
        {
            return new Category() { Name = name };
        }
    }
}
