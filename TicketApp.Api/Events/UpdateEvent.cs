namespace TicketApp.Api.Events
{
    public class UpdateEvent<TObject, TEvent> : CommandEvent
    {
        public TObject Object {
            get;
            set;
        }
    }
}

