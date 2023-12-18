using System.Collections.Generic;
using TicketApp.Api.Objects;

namespace TicketApp.Api.Events.Ticket
{
    public class TicketsReadEvent:ResponseEvent<TicketsReadEvent, List<TicketDetails>> 
    {
    }
}

