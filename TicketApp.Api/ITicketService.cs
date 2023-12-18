using TicketApp.Api.Events.Ticket;

namespace TicketApp.Api
{
    public interface ITicketService
    {
        TicketsReadEvent List(ReadTicketsEvent @event);

        TicketCreatedEvent Create(CreateTicketEvent ticket);

        TicketUpdatedEvent Update(UpdateTicketEvent ticket);

        TicketDeletedEvent Delete(DeleteTicketEvent ticket);
    }
}

