using System;

namespace TicketApp.Api.Objects
{
    public class TicketFullView
    {
        public int Code{get;set;}
        public DateTime Creation{get;set;}
        public String Account{get;set;}
        public String AccountEmail{get;set;}
        public int Priority{get;set;}
    }
}

