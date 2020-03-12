using System;

namespace TicketApp.Api
{
    public class ResponseEvent<EVT, OBJ> : OutputEvent
        where  EVT: ResponseEvent<EVT, OBJ>
    {
        public OBJ Object {
            get;
            set;
        }

        public ResponseEvent() {
        }

        public EVT Ok() {
            Code = ResponseCode.OK;
            return (EVT) this;
        }

        public EVT NotFound() {
            Code = ResponseCode.OBJECT_NOT_FOUND;
            return (EVT) this;
        }
    }
}

