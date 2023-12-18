using TicketApp.Api.Objects;

namespace TicketApp.Api.Events.Ticket
{
    public class CreateTicketEvent:UpdateEvent<TicketDetails, CreateTicketEvent>
    {
        public CreateTicketEvent (TicketDetails ticket)
        {
            Object = ticket;
        }
    }
}

