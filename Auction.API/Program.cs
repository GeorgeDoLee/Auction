using Auction.Application.Extensions;
using Auction.Infrastructure.Extensions;
using Auction.Infrastructure.Seeders;
using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Host.UseSerilog((context, configuration) =>
    configuration
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Information)
        .WriteTo.Console(outputTemplate: "[{Timestamp:dd-MM HH:mm:ss} {Level:u3}] |{SourceContext}| {NewLine}{Message:lj}{NewLine}{Exception}")
);

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var seeder = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();
//    await seeder.SeedAsync();
//}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
