using LogSys.Aplication.DTOs;
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
		public async Task<IActionResult> CreateLog(CreateLogDto logDto)
		{
			return Ok(await Mediator.Send(new Create.command { LogDto = logDto }));
		}

		[HttpGet]
		[Route("logs")]

		public async Task<ActionResult> GetLogs([FromQuery] LogParams param)
		{
			switch (param?.ColumnValue?.ToLower())
			{
				case "title":
				case "level":
				case "message":
				case "userid":	
				{
					return HandlePagedResult(await Mediator.Send(new List.Query1 { Params = param }));

				}
				default:
				{
					return HandlePagedResult(await Mediator.Send(new List.Query { Params = param }));
				}
			}
		}

		[HttpGet]
		[Route("User/{userid}/GetReport")]

		public async Task<IActionResult> GetReport([FromRoute]string userid, [FromQuery] LogReportParams param)
		{
			return HandleResult(await Mediator.Send(new List.Query2 { reportParams = param, userId = userid }));
		}

	}
}
