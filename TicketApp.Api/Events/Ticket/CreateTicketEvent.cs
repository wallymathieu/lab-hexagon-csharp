using System;

namespace TicketApp.Api
{
    public class CreateTicketEvent:UpdateEvent<TicketDetails, CreateTicketEvent>
    {
        public CreateTicketEvent (TicketDetails ticket)
        {
            Object = ticket;
        }
    }
}

