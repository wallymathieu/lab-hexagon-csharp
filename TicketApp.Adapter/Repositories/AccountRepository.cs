using TicketApp.Application.Domain;

namespace TicketApp.Application.Repositories
{
    internal class AccountRepository : Repository<Account, string>, IAccountRepository
    {
        public AccountRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}