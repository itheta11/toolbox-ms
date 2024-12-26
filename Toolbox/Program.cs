using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Toolbox.Filters;
using Toolbox.Infrastructure;
using Toolbox.Repo.Implementations;
using Toolbox.Repo.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment;
var config = builder.Configuration;

// Add configuration

config.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true);
// Add services to the container.

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
});
builder.Services.AddControllers(x => x.Filters.Add<ApiExceptionFilterAttribute>());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        var allowedOrigins = config.GetSection("AllowedOrigins").Get<string[]>();
        builder.WithOrigins(allowedOrigins)
            .SetIsOriginAllowedToAllowWildcardSubdomains()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
        ;
    });
});
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

/// custom services
builder.Services.AddDbContext<ToolboxContext>(options =>
    options.UseNpgsql(config.GetSection("Toolbox").Get<string>())
);
builder.Services.AddScoped<IJsonschema, JsonschemaRepo>();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
