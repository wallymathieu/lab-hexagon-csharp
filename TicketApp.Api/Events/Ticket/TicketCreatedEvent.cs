using TicketApp.Api.Objects;

namespace TicketApp.Api.Events.Ticket
{
    public class TicketCreatedEvent:ResponseEvent<TicketCreatedEvent, TicketDetails>
    {
        public TicketCreatedEvent (TicketDetails ticket)
        {
            Object = ticket;
        }
    }
}

