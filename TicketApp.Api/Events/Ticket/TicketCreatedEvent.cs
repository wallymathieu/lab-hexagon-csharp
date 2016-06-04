using System;

namespace TicketApp.Api
{
    public class TicketCreatedEvent:ResponseEvent<TicketCreatedEvent, TicketDetails>
    {
        public TicketCreatedEvent (TicketDetails ticket)
        {
            Object = ticket;
        }
    }
}

