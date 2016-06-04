using System;

namespace TicketApp.Api
{
    public class UpdateTicketEvent:UpdateEvent<TicketDetails, UpdateTicketEvent>
    {
        public UpdateTicketEvent (TicketDetails ticket)
        {
            Object = ticket;
        }
    }
}

