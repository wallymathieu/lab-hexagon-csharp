using System;

namespace TicketApp.Api
{
    public class OutputEvent
    {
        public ResponseCode Code { get; set; }


        public OutputEvent() {
            Code =  ResponseCode.OK;
        }
    }
}

