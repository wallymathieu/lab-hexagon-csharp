using TicketApp.Api;
using Xunit;

namespace TicketApp.Application.Tests
{
//@SpringApplicationConfiguration(classes = TicketappApplication.class)
	public class IntegrationTest {

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

			Assert.Equal(ResponseCode.OK, evtOutput.Code);
			
			TicketDetails output = evtOutput.Object;

			Assert.Equal(5, output.Priority);
			Assert.True(output.Code > 0);
		}
	}

}