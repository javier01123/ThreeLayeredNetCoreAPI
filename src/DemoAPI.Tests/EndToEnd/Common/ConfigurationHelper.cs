using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.Tests.EndToEnd.Common
{
    public static class ConfigurationHelper
    {
        public static IConfiguration GetTestConfiguration()
            => new ConfigurationBuilder()
                .AddJsonFile("endToEndSettings.json")
                .Build();
    }
}
