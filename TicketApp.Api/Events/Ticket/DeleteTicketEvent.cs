using System;

namespace TicketApp.Api
{
    public class DeleteTicketEvent:CommandEvent
    {
        public int Code {
            get;
            set;
        }
    }
}

