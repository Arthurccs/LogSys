using LogSys.Aplication.Core;
using System;

namespace LogSys.Aplication.DTOs
{
	public class LogParams : PagingParams
	{
		public DateTime From { get; set; } = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 0, 0, 0);
		public DateTime To { get; set; } = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 23, 59, 59);
		public string ColumnValue { get; set; }
		public string ColumnSort { get; set; }
	}
}
