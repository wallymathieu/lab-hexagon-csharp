using System;
using TicketApp.Application.Domain;

namespace TicketApp.Application.Repositories
{
    public interface IAccountRepository : IRepository<Account, String> {

    }
}