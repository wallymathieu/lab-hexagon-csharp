namespace TicketApp.Api.Events
{
    public class ResponseEvent<TEvent, TObject> : OutputEvent
        where  TEvent: ResponseEvent<TEvent, TObject>
    {
        public TObject Object {
            get;
            set;
        }

        public ResponseEvent() {
        }

        public TEvent Ok() {
            Code = ResponseCode.Ok;
            return (TEvent) this;
        }

        public TEvent NotFound() {
            Code = ResponseCode.ObjectNotFound;
            return (TEvent) this;
        }
    }
}

