using System;

namespace TicketApp.Api
{
    public class ResponseEvent<EVT, OBJ> : OutputEvent
        where  EVT: OutputEvent 
    {
        public OBJ Object {
            get;
            set;
        }

        public ResponseEvent() {
        }

        public EVT ok() {
            code = ResponseCode.OK;
            return (EVT) this;
        }

        public EVT notFound() {
            code = ResponseCode.OBJECT_NOT_FOUND;
            return (EVT) this;
        }
    }
}

