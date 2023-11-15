using System.Reflection;
using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Managers;
using Akcay.Application.Common.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Akcay.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddOptions();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MappingProfile).Assembly));
        services.AddTransient<IFileService, FileManager>();
        return services;
    }
}