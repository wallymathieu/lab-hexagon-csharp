using TicketApp.Application.Domain;
using TicketApp.Application.Repositories;

namespace TicketApp.Adapter.Repositories
{
    internal class AccountRepository(AppDbContext appDbContext)
        : Repository<Account, string>(appDbContext), IAccountRepository;
}