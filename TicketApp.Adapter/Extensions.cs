using Microsoft.Extensions.DependencyInjection;
using TicketApp.Adapter.Repositories;
using TicketApp.Application.Repositories;

namespace TicketApp.Adapter
{
    public static class Extensions
    {
        public static IServiceCollection AddDbRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();

            return services;
        }
    }
}