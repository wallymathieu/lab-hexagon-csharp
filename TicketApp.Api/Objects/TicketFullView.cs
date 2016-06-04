using System;

namespace TicketApp.Api
{
    public class TicketFullView
    {
        public int code{get;set;}
        public DateTime creation{get;set;}
        public String account{get;set;}
        public String accountEmail{get;set;}
        public int priority{get;set;}
    }
}

