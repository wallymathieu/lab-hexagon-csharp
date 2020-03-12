using System;
using System.Collections.Generic;
using System.Linq;
using TicketApp.Api;
using TicketApp.Application.Domain;
using TicketApp.Application.Repositories;

namespace TicketApp.Application.Handlers
{
    public class TicketServiceHandler : ITicketService
    {
        public TicketServiceHandler(ITicketRepository ticketRepository, IAccountRepository accountRepository)
        {
            this.ticketRepository = ticketRepository;
            this.accountRepository = accountRepository;
        }
        private ITicketRepository ticketRepository;

        private IAccountRepository accountRepository;

        public TicketsReadEvent List(ReadTicketsEvent @event)
        {
            TicketsReadEvent outputEvt = new TicketsReadEvent();

            List<Ticket> entities = ticketRepository.FindAll().ToList();

            if (!entities.Any())
            {
                return new TicketsReadEvent().NotFound();
            }

            List<TicketDetails> output = new List<TicketDetails>();
            foreach (Ticket entity in entities)
            {
                output.Add(entity.ToTicketDetails());
            }

            return outputEvt;

        }

        public TicketCreatedEvent Create(CreateTicketEvent @event)
        {

            Ticket entity = Ticket.FromTicketDetails(@event.Object);

            // Use case rules go here
            // Use service composition to call other services
            entity.Creation = new DateTime();
            Account account = accountRepository.FindOne(@event.Object.Account);
            entity.Account = account;
            entity = ticketRepository.Save(entity);

            return new TicketCreatedEvent(entity.ToTicketDetails());
        }

        public TicketUpdatedEvent Update(UpdateTicketEvent @event)
        {
            Ticket entity = Ticket.FromTicketDetails(@event.Object);
            entity = ticketRepository.Save(entity);
            return new TicketUpdatedEvent(entity.ToTicketDetails());
        }

        public TicketDeletedEvent Delete(DeleteTicketEvent ticket)
        {
            try
            {
                ticketRepository.Delete(ticket.Code);
            }
            catch (EmptyResultDataAccessException)
            {
                return new TicketDeletedEvent().NotFound();
            }
            return new TicketDeletedEvent();
        }

    }
}