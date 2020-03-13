using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketApp.Application.Domain
{
	public class Account 
    {
		[Key]
		public String Login{get;set;}
		public String Email{get;set;}
    }
}