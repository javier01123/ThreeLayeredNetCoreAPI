using DemoAPI.BLL.Services.Categories.UpdateCategory;
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
    public class UpdateTests : ControllerTestBase
    {
        public const string ENDPOINT = "api/categories/";


        [Test]
        public async Task test_update_valid_category()
        {
            var cmd = new UpdateCategoryCmd()
            {
                CategoryId = 1,
                Name = "new name"
            };

            var response = await _httpClient.PutAsync(ENDPOINT, GetContentFromCmd(cmd));
            response.EnsureSuccessStatusCode();

            var updatedCategory = await response.Deserialize<UpdateCategoryCmd>();
            Assert.AreEqual(cmd.Name, updatedCategory.Name);
        }
    }
}
