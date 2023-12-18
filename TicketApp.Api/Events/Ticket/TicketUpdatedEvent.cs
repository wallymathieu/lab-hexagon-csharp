using TicketApp.Api.Objects;

namespace TicketApp.Api.Events.Ticket
{
    public class TicketUpdatedEvent:ResponseEvent<TicketUpdatedEvent, TicketDetails>
    {
        public TicketUpdatedEvent (TicketDetails ticket)
        {
            Object = ticket;
        }
    }
}

