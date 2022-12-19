using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tarea.Infraestructura.SQL.SQL_Server.Contextos;

namespace Tarea.API.Extenciones
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureSQLDbContext(this IServiceCollection services, string SqlConnection)
        {
            services.AddDbContext<SQLContext>(opt =>
            {
                opt.UseSqlServer(SqlConnection);
            });
        }
    }
}
