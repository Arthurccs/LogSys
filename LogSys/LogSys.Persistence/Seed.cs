using LogSys.Domain;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogSys.Persistence
{
	public class Seed  
	{
		public static async Task SeedData(DataContext context)
		{
			if (context.Logs.Any())
			{
				return;
			}
			var logs = new List<Log>
			{
				new Log
				{
					Title ="Test Title1",
					Message = "Message 1",
					Datetimecreation = DateTime.Now,
					Level = "error",
					Userid = "CRUIZ"
				},
				new Log
				{
					Title ="Test Title2",
					Message = "Message 2",
					Datetimecreation = DateTime.Now,
					Level = "error",
					Userid = "ARTURO"
				},
				new Log
				{
					Title ="Test Title3",
					Message = "Message 3",
					Datetimecreation = DateTime.Now.AddMonths(12),
					Level = "error",
					Userid = "CRUIZ"
				},
				new Log
				{
					Title ="Test Title4",
					Message = "Message 4",
					Datetimecreation = DateTime.Now.AddMonths(1),
					Level = "error",
					Userid = "CRUIZ"
				},
				new Log
				{
					Title ="Test Title5",
					Message = "Message 5",
					Datetimecreation = DateTime.Now.AddMonths(2),
					Level = "error",
					Userid = "CRUIZ"
				},
			};
			await context.Logs.AddRangeAsync(logs);
			await context.SaveChangesAsync();

		}

	}
}
