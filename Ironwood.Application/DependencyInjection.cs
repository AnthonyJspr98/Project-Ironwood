﻿using AutoMapper;
using Ironwood.Application.Common;
using Ironwood.Application.Common.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ironwood.Application
{
    public static class  DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, bool includeValidators = false)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            if (includeValidators)
            {
                services.AddValidators(Assembly.GetExecutingAssembly());
            }

            return services;
        }

    }
}
