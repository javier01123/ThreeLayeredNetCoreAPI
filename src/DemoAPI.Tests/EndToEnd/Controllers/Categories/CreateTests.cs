using DemoAPI.BLL.Services.Categories.CreateCategory;
using DemoAPI.EndToEnd.Common;
using DemoAPI.Tests.EndToEnd.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.Tests.EndToEnd.Controllers.Categories
{
    [TestFixture]
    public class CreateTests : ControllerTestBase
    {
        private const string ENDPOINT = "/api/categories/";

        [Test]
        public async Task test_create_valid_category()
        {
            var cmd = new CreateCategoryCmd()
            {
                Name = "medical instruments"
            };
         
            var response = await _httpClient.PostAsync(ENDPOINT, GetContentFromCmd(cmd));
            response.EnsureSuccessStatusCode();

            var category = await response.Deserialize<CreateCategoryRes>();
            Assert.Greater(category.CategoryId, 0);
            Assert.IsNotEmpty(category.Name);
        }

    }
}
