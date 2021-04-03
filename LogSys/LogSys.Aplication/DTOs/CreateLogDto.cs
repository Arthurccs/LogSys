using System;
using System.Collections.Generic;
using System.Text;

namespace LogSys.Aplication.DTOs
{
	public class CreateLogDto
	{
		public string Title { get; set; }
		public string Level { get; set; }
		public string Message { get; set; }
		public string Userid { get; set; }
	}
}
