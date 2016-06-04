using System;

namespace TicketApp.Api
{
    public class OutputEvent
    {
        public ResponseCode code { get; set; }


        public OutputEvent() {
            code =  ResponseCode.OK;
        }
    }
}

