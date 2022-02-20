using DemoAPI.DAL;
using DemoAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.Tests.EndToEnd.Common
{
    public static class SeedDatabase
    {
        public static async Task InitializeDbForTests(DemoAPIContext context)
        {
            context.Add(new Category("electronics"));

            await context.SaveChangesAsync();
        }
    }
}
