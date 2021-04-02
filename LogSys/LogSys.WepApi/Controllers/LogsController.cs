using LogSys.Aplication.Logs;
using LogSys.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogSys.WepApi.Controllers
{
	public class LogsController : BaseApiController
	{
		
		[HttpPost]
		[Route("logs")]
		public async Task<IActionResult> CreateLog(Log log)
		{
			return Ok(await Mediator.Send(new Create.command { Log = log }));
		}

		[HttpGet]
		[Route("logs")]

		public async Task<ActionResult<List<Log>>> GetLogs()
		{
			return await Mediator.Send(new List.Query());
		}

		[HttpGet]
		[Route("User/{userid}/GetReport/{from}/{to}")]

		public int GetReport([FromRoute]string userid, [FromRoute]string from, [FromRoute]string to)
		{
			//return _context.Logs.Where(x => x.Userid == userid).Count();
			return 5;
		}

	}
}
