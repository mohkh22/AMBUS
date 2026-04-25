using AMBUS.Application.Mapping;
using AMBUS.Domain.Models;
using AutoMapper;

using Microsoft.Extensions.DependencyInjection;
using System;


namespace AMBUS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesFromApplication(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(MappingProfile).Assembly); 

            return services;
        }
    }
}
