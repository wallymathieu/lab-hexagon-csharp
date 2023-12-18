namespace TicketApp.Api.Events.Ticket
{
    public class DeleteTicketEvent:CommandEvent
    {
        public int Code {
            get;
            set;
        }
    }
}

