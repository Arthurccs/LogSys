using LogSys.Domain;
using LogSys.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
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
		public async Task<ActionResult<List<Log>>> GetLogs()
		{
			return await _context.Logs.ToListAsync();	
		}

		[HttpGet]
		[Route("api/User/{userid}/GetReport")]

		public int GetReport([FromBody]string userid, DateTime? from, DateTime? to)
		{
			return _context.Logs.Where(x => x.Userid == userid).Count();
		}

	}
}
