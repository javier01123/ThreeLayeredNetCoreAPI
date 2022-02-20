using System.Collections.Generic;

namespace DemoAPI.DAL.Models
{
    public class Category
    {
        private Category() { }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }



        public static Category FromName(string name)
        {
            return new Category() { Name = name };
        }
    }
}
