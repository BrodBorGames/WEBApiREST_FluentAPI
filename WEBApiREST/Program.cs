using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebAPI1.Repositories;
using WEBApiREST;
using WEBApiREST.Endpoints;
using WEBApiREST.Extensions;
using WEBApiREST.Interfaces;
using WEBApiREST.Middleware;
using Microsoft.OpenApi.Models;
using FluentMigrator.Runner;
using System.Reflection;
using WEBApiREST.Repositories;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;
var databaseConnectionString = GetDatabaseConnectionString();

// Add services to the container.


builder.Services.AddDbContext<ApplicationContext>(
    options =>
    {
        options.UseNpgsql(databaseConnectionString);
    });
//services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));


services.AddLogging(c => c.AddFluentMigratorConsole())
                .AddFluentMigratorCore()
                .ConfigureRunner(c => c
                    .AddPostgres()
                     .WithGlobalConnectionString(databaseConnectionString)
                     .ScanIn(Assembly.GetExecutingAssembly()).For.All());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<ICollegeRepository, CollegeRepository>();



services.AddCors();

services.AddBearerAuthentication(configuration);
services.AddScoped<TokenServiceMiddleware>();
services.AddScoped<IDataSeed, DataSeed>();
services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        In = ParameterLocation.Header,
        Description = "Basic Authorization header using the Bearer scheme."
    });
    c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme()
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Description = "Input bearer token to access this API",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                    },
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "bearerAuth"
                            }
                        },
                        new string[] { }
                    }
                });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseDeveloperExceptionPage();
}
//app.UseCookiePolicy(new CookiePolicyOptions
//{
//    MinimumSameSitePolicy = SameSiteMode.Strict,
//    HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,
//    Secure = CookieSecurePolicy.Always
//});

app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true).WithOrigins("http://localhost:4200", "http://localhost:8080") // allow any origin
                                                        //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins separated with comma
                    .AllowCredentials()); // allow credentials

app.UseAuthentication();

app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.AddApplicationServices();
app.Migrate();




app.Run();


string GetDatabaseConnectionString() =>
    configuration.GetConnectionString("DatabaseConnection") ??
    throw new InvalidOperationException("Строка подключения к БД не задана в конфигурации (секция ConnectionStrings__DatabaseConnection).");