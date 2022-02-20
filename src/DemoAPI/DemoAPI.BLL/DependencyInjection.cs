using DemoAPI.BLL.Pipeline;
using DemoAPI.DAL;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DemoAPI.BLL
{
    public static class DependencyInjection
    {
        public static void AddBLLDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DemoAPIContext>(options =>
                        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                    );

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        }
    }
}
