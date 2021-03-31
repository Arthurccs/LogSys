using LogSys.Domain;
using LogSys.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogSys.WepApi.Controllers
{
	public class LogsController : BaseApiController
	{
		private readonly DataContext _context;
		public LogsController(DataContext context)
		{
			_context = context;
		}

		[HttpGet]
		[Route("logs")]

		public async Task<ActionResult<List<Log>>> GetLogs()
		{
			return await _context.Logs.ToListAsync();	
		}

		[HttpGet]
		[Route("User/{userid}/GetReport/{from}/{to}")]

		public int GetReport([FromRoute]string userid, [FromRoute]string from, [FromRoute]string to)
		{
			return _context.Logs.Where(x => x.Userid == userid).Count();
		}

	}
}
