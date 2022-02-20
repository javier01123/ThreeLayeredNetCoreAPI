using DemoAPI.BLL.Services.Categories.CreateCategory;
using DemoAPI.EndToEnd.Common;
using DemoAPI.Tests.EndToEnd.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.Tests.EndToEnd.Controllers
{
    [TestFixture]
    public class CategoryTests:ControllerTestBase
    {
        [Test]
        public async Task test_create_valid_category()
        {
            var cmd = new CreateCategoryCmd()
            {
                Name = "medial instruments"
            };

            var content = Utilities.GetRequestContent(cmd);
            var response = await _httpClient.PostAsync($"/api/categories/", content);
            response.EnsureSuccessStatusCode();
        }        
    }
}
