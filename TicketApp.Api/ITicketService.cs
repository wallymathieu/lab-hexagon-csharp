using System;

namespace TicketApp.Api
{
    public interface ITicketService {

        TicketsReadEvent list(ReadTicketsEvent @event);

        TicketCreatedEvent create(CreateTicketEvent ticket);

        TicketUpdatedEvent update(UpdateTicketEvent ticket);

        TicketDeletedEvent delete(DeleteTicketEvent ticket);
    }
}

