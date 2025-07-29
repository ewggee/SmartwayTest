using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartwayTest.Contracts.Dapper;
using SmartwayTest.Contracts.Settings;
using SmartwayTest.DataAccess.Dapper;
using SmartwayTest.DataAccess.Repositories;
using SmartwayTest.Domain.Migrations;
using SmartwayTest.Domain.Repositories;

namespace SmartwayTest.DataAccess.Extensions;

public static class DataAccessExtensions
{
    public static IServiceCollection AddDapper(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDapperContext, DapperContext>();

        services.Configure<DapperSettings>(o =>
        {
            o.ConnectionString = configuration.GetConnectionString("DefaultConnection")!;
        });

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IPassportRepository, PassportRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();

        return services;
    }

    public static IServiceCollection AddFluentMigrator(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddFluentMigratorCore()
            .ConfigureRunner(builder => builder
                .AddPostgres()
                .WithGlobalConnectionString(configuration.GetConnectionString("DefaultConnection")!)
                .ScanIn(typeof(M001_Initial).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);

        return services;
    }

    public static IServiceCollection MigrateUp(this IServiceCollection services)
    {
        using (var scope = services.BuildServiceProvider().CreateScope())
        {
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            runner.ListMigrations();
            runner.MigrateUp();
        }

        return services;
    }
}
