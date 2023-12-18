using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TicketApp.Api;
using TicketApp.Api.Events.Ticket;
using TicketApp.Api.Objects;
using TicketApp.Application.Domain;
using TicketApp.Application.Repositories;

namespace TicketApp.Adapter.Controllers
{
    [ApiController, Route("/api/v1/tickets")]
    public class TicketsController(ITicketService ticketService): ControllerBase
    {
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

