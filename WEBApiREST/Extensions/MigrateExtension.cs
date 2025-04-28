using System.Reflection;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WEBApiREST.Extensions
{
    public static class MigrateExtension
    {

        public static IApplicationBuilder Migrate(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var runner = scope.ServiceProvider.GetService<IMigrationRunner>();
            runner.ListMigrations();
            runner.MigrateUp(4);
            return app;
        }
    }
}
