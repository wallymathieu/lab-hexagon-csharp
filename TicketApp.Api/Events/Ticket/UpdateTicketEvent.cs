using TicketApp.Api.Objects;

namespace TicketApp.Api.Events.Ticket
{
    public class UpdateTicketEvent:UpdateEvent<TicketDetails, UpdateTicketEvent>
    {
        public UpdateTicketEvent (TicketDetails ticket)
        {
            Object = ticket;
        }
    }
}

