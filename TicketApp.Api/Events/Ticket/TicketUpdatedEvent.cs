using System;

namespace TicketApp.Api
{
    public class TicketUpdatedEvent:ResponseEvent<TicketUpdatedEvent, TicketDetails>
    {
        public TicketUpdatedEvent (TicketDetails ticket)
        {
            Object = ticket;
        }
    }
}

