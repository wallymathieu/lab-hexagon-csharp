using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TicketApp.Api;
using TicketApp.Application.Domain;
using TicketApp.Application.Repositories;

namespace TicketApp.Adapter
{
    [ApiController, Route("/api/v1/tickets")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService ticketService;

        public TicketsController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }
        [HttpPost("",Name="Create")]
        public IActionResult Create([FromBody] TicketDetails ticket)
        {
            CreateTicketEvent @event = new CreateTicketEvent(ticket);
            TicketCreatedEvent outputEvt = ticketService.Create(@event);
            Ticket output = Ticket.FromTicketDetails(outputEvt.Object);
            return CreatedAtRoute("Get", new { code = outputEvt.Object.Code }, output);
        }

        [HttpGet(Name = "GetAll")]
        public IList<Ticket> GetAll()
        {
            List<Ticket> tickets = new List<Ticket>();
            TicketsReadEvent output = ticketService.List(new ReadTicketsEvent());

            foreach (TicketDetails ticket in output.Object)
            {
                tickets.Add(Ticket.FromTicketDetails(ticket));
            }
            return tickets;
        }
        [HttpGet("{code}", Name = "Get")]
        public Ticket Get(int code, [FromServices]ITicketRepository ticketRepository)
        {
            return ticketRepository.FindOne(code);
        }
    }
}

