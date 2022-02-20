
using DemoAPI.DAL;
using DemoAPI.Tests.EndToEnd.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace API.IntegrationTests.Common
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        public CustomWebApplicationFactory()
        {
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .ConfigureServices(services =>
                {
                    // quitar el registro del contexto de producción
                    var contextDescriptor = services.SingleOrDefault(
                        d => d.ServiceType == typeof(DbContextOptions<DemoAPIContext>));

                    if (contextDescriptor != null)
                        services.Remove(contextDescriptor);       
                    var configuration = ConfigurationHelper.GetTestConfiguration();
                    var _connectionString = configuration.GetConnectionString("TestDbConnection");

                    services.AddDbContext<DemoAPIContext>(options =>
                   {
                       options.UseNpgsql(_connectionString, b => b.MigrationsAssembly("DemoAPI.DAL"));
                   }); ;
          
                    var sp = services.BuildServiceProvider();
                    var scope = sp.CreateScope();
                    var scopedServices = scope.ServiceProvider;
                    var context = scopedServices.GetRequiredService<DemoAPIContext>() as DemoAPIContext;
                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();

                    try
                    {
                        SeedDatabase.InitializeDbForTests(context);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"error al inicializar la base de datos. Error: {ex.Message}");
                    }

                })
                .UseEnvironment("Test");
                //.UseSetting("https_port", "44362");
        }

        public HttpClient GetAnonymousClient()
        {
            return CreateClient();
        }
        
    }
}
