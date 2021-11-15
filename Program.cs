using System.Reflection;
using DutyAndConductorManager.Api.Contexts;
using DutyAndConductorManager.Api.Helpers;
using DutyAndConductorManager.Api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((context, config) => {
    config.SetBasePath(context.HostingEnvironment.ContentRootPath);
    config.AddJsonFile("appsettings.json", false, true);
    config.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", true, true);
    config.AddCommandLine(args);
    config.AddEnvironmentVariables();
});

builder.Host.UseSerilog((context, services, config) => config
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext()
    .WriteTo.Console()
);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Duty and Conductor Manager Api", Version = "v1" });
});
builder.Services.AddDbContext<ConductorDb>(config =>
{
    config.UseSqlServer(builder.Configuration.GetConnectionString("ConductorDb"));
    if (builder.Environment.IsDevelopment())
        config.EnableSensitiveDataLogging(true);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Duty and Conductor Manager Api v1"));
}

app.UseSerilogRequestLogging();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseHttpsRedirection();

app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
