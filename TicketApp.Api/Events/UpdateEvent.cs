using System;

namespace TicketApp.Api
{
    public class UpdateEvent<OBJ, EVT> : CommandEvent
    {
        public OBJ Object {
            get;
            set;
        }
    }
}

