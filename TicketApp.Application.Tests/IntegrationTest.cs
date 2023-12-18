using Microsoft.Extensions.DependencyInjection;
using TicketApp.Api;
using Xunit;
using TicketApp.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using TicketApp.Adapter;
using TicketApp.Adapter.Repositories;
using TicketApp.Api.Events;
using TicketApp.Api.Events.Ticket;
using TicketApp.Api.Objects;
using TicketApp.Application.Handlers;

namespace TicketApp.Application.Tests
{
    public class IntegrationTest:IDisposable
    {
        public IntegrationTest()
        {
            var services=new ServiceCollection().AddLogging();
            services.AddDbRepositories();
            var rnd = Guid.NewGuid().ToString("N");
            var opts = new DbContextOptionsBuilder()
                  .UseInMemoryDatabase(databaseName: $"ticketapp_integration_tests_{rnd}")
                  .Options;
            services.AddScoped(di=>new AppDbContext(opts));
            services.AddScoped<ITicketService, TicketServiceHandler>();
            var provider = services.BuildServiceProvider();
            scope =provider.CreateScope();
            ticketService = scope.ServiceProvider.GetRequiredService<ITicketService>();
        }

        private IServiceScope scope;

        //@Autowired
        private ITicketService ticketService;

        [Fact]
        public void TestCreateTicket()
        {
            TicketDetails ticket = new TicketDetails();
            ticket.Account = "root";
            ticket.Priority = 5;

            CreateTicketEvent @event = new CreateTicketEvent(ticket);

            TicketCreatedEvent evtOutput = ticketService.Create(@event);

            Assert.Equal(ResponseCode.Ok, evtOutput.Code);

            TicketDetails output = evtOutput.Object;

            Assert.Equal(5, output.Priority);
            Assert.True(output.Code > 0);
        }

        public void Dispose() => scope.Dispose();
    }

}