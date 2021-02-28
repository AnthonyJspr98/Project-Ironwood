
using Ironwood.Application.Common.Interfaces;
using Ironwood.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ironwood.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddDbContext<IronwoodDbContext>(options => options.UseSqlServer
            (
                connectionString: configuration.GetConnectionString("IronwoodConStr")
            ));
            services.AddScoped<IIronwoodDbContext>(provider => provider.GetService<IronwoodDbContext>());
            services.AddScoped<DbContext>(provider => provider.GetService<IronwoodDbContext>());

            return services;
        }
    }
}
