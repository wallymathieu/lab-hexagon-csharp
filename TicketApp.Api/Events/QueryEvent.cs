namespace TicketApp.Api.Events
{
    public class QueryEvent
    {
        public int Offset{ get; set;}
        public int Limit{ get; set;}
        public int Total{ get; set;}
    }
}

