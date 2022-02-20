﻿using System.Collections.Generic;

namespace DemoAPI.DAL.Models
{
    public class Category
    {        
        public Category(string name)
        {
            Name = name;
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }         
    }
}
