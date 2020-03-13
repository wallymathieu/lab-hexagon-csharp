using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TicketApp.Adapter;
using TicketApp.Api;
using TicketApp.Application.Handlers;

namespace TicketApp.Application.Repositories
{
    public class Startup
    {
        private SwaggerConfig _swagger = new SwaggerConfig();

        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            _swagger.ConfigureServices(services);
            services.AddScoped<TicketsController>();
            services.AddControllers();
            services.AddDbRepositories();
            services.AddScoped<ITicketService, TicketServiceHandler>();
            ConfigureDbContext(services);
        }
        protected virtual void ConfigureDbContext(IServiceCollection services)
        {
            switch (Configuration["DB"]?.ToLowerInvariant())
            {
                case "inmemory":
                    services.AddDbContext<AppDbContext>(options =>
                        options.UseInMemoryDatabase(databaseName: Configuration.GetConnectionString("TicketApp")));
                    break;
                case "sqlite":
                    services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlite(Configuration.GetConnectionString("TicketApp")));
                    break;
                case "sqlserver":
                    services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("TicketApp")));
                    break;
                default:
                    throw new Exception("Expected DB type");
            }
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            _swagger.Configure(app);
        }
    }
}