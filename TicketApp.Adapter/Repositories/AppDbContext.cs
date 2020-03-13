using Microsoft.EntityFrameworkCore;
using TicketApp.Application.Domain;

namespace TicketApp.Application.Repositories
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}