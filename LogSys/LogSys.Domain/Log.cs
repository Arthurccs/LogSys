using System;

namespace LogSys.Domain
{
	public class Log
	{
		/*● title: short text
		● level: keywords like error, information, warning, trace, ...
		● message: long text description
		● userid: just a text field at first
		● datetimecreation: when the log entry was created
		*/

		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Level { get; set; }
		public string Message { get; set; }
		public string Userid { get; set; }
		public DateTime Datetimecreation { get; set; }
	}
}
