using System;
using System.Collections.Generic;

namespace TicketApp.Api
{
    public class TicketsReadEvent:ResponseEvent<TicketsReadEvent, List<TicketDetails>> 
    {
    }
}

