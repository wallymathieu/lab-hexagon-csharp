using System;
using System.Collections.Generic;
using TicketApp.Application.Domain;

namespace TicketApp.Application.Repositories
{
    public interface ITicketRepository : IRepository<Ticket, int> {

        List<Ticket> FindByPriority(int priority);

        List<Ticket> FindByCreationIsAfter(DateTime creation);

        List<Ticket> FindByCreationIsAfterAndPriority(DateTime creation, int priority);
        //
    }
}