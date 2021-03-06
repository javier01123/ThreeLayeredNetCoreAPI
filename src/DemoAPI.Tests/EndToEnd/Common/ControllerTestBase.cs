using API.IntegrationTests.Common;
using DemoAPI.Web;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.EndToEnd.Common
{
    public abstract class ControllerTestBase
    {
        protected CustomWebApplicationFactory<Startup> _factory;
        protected HttpClient _httpClient;

        [SetUp]
        public async virtual Task SetUp()
        {
            _factory = new CustomWebApplicationFactory<Startup>();
            _httpClient = _factory.GetAnonymousClient();
        }

        //todo: check test concurrency and tear down changes
        [TearDown]
        public virtual void TearDown()
        {

        }


        public StringContent GetContentFromCmd(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }
  
    }
}
