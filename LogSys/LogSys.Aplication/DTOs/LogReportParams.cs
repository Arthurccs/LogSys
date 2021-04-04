using System;


namespace LogSys.Aplication.DTOs
{
	public class LogReportParams
	{
		//public string UserId { get; set; }
		public DateTime From { get; set; } /*= new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 0, 0, 0);*/
		public DateTime To { get; set; } = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 23, 59, 59);
	}
}
