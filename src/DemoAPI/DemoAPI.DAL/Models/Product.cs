using System.Collections.Generic;

namespace DemoAPI.DAL.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }  
        public uint xmin { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
