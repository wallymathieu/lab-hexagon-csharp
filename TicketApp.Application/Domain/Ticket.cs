using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicketApp.Api;

namespace TicketApp.Application.Domain
{
    public class Ticket
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }
        public DateTime Creation { get; set; }
        public int Priority { get; set; }
        public String Description { get; set; }

        //@ManyToOne
        public Account Account { get; set; }
        /**
         * Translate the domain model to the API
         * 
         * @return the transfer object
         */
        public TicketDetails ToTicketDetails()
        {
            TicketDetails transferObject = new TicketDetails();

            transferObject.Code = this.Code;
            transferObject.Creation = this.Creation;
            transferObject.Priority = this.Priority;

            Account account = this.Account;
            if (account != null)
            {
                // Loading other domain model dependencies
                transferObject.Account = account.Login;
            }
            return transferObject;
        }

        /**
         * Translate the ticket to the domain model
         * 
         * @param ticketDetails
         * @return model
         */
        public static Ticket FromTicketDetails(TicketDetails ticketDetails)
        {
            Ticket domain = new Ticket();
            domain.Code = ticketDetails.Code;
            domain.Creation = ticketDetails.Creation;
            domain.Priority = ticketDetails.Priority;
            return domain;
        }

        public override String ToString()
        {
            return "Ticket [code=" + Code + ", creation=" + Creation + ", priority=" + Priority + ", description="
                    + Description + ", account=" + Account + "]";
        }
    }
}