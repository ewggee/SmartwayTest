using SmartwayTest.Application.Extensions;
using SmartwayTest.DataAccess.Extensions;

namespace SmartwayTest.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddServices()
            .AddDapper(builder.Configuration)
            .AddRepositories()
            .AddFluentMigrator(builder.Configuration)
            .MigrateUp();

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapControllers();

        app.Run();
    }
}
