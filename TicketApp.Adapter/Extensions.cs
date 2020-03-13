using Microsoft.Extensions.DependencyInjection;

namespace TicketApp.Application.Repositories
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