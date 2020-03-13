using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace TicketApp.Application.Repositories
{
    class SwaggerConfig
    {
        ///
        public void Configure(IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger(c => { c.RouteTemplate = "swagger/{documentName}/swagger.json"; });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
                c.EnableDeepLinking();
            });
        }

        ///
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options => { });

            services.ConfigureSwaggerGen(options =>
            {
                var webAssembly = typeof(Startup).GetTypeInfo().Assembly;
                var informationalVersion =
                    (webAssembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute))
                        as AssemblyInformationalVersionAttribute[])?.First()?.InformationalVersion;

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = informationalVersion ?? "dev",
                    Title = "API",
                    Description = "Some API"
                });

                //Set the comments path for the swagger json and ui.
                var xmlPath = typeof(Startup).Assembly.Location + ".xml";
                if (File.Exists(xmlPath))
                    options.IncludeXmlComments(xmlPath);
            });
        }
    }
}