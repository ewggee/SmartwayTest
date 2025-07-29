using Microsoft.Extensions.DependencyInjection;
using SmartwayTest.Application.Services;

namespace SmartwayTest.Application.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();

        return services;
    }
}
