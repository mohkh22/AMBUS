using AMBUS.Application.Mapping;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;


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
