using DemoAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DemoAPI.BLL
{
    public static class DependencyInjection
    {
        public static void AddBLLDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DemoAPIContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                    );
        }
    }
}
