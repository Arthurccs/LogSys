using LogSys.Aplication.Core;
using LogSys.Aplication.DTOs;
using LogSys.Domain;
using LogSys.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogSys.Aplication.Logs
{
	/// <summary>
	/// To get Logs
	/// </summary>
	public class List
	{
		public class Query : IRequest<Result<PagedList<Log>>>
		{
			public LogParams Params { get; set; }
		}
		public class Handler : IRequestHandler<Query, Result<PagedList<Log>>>
		{
			private readonly DataContext _context;
			private readonly ILogger<List> _logger;

			public Handler(DataContext context, ILogger<List> logger)
			{
				_context = context;
				_logger = logger;
			}
			public async Task<Result<PagedList<Log>>> Handle(Query request, CancellationToken cancellationToken)
			{
				_logger.LogInformation("Runnig get Logs");
				var query = _context.Logs
				   .Where(d => d.Datetimecreation >= request.Params.From && d.Datetimecreation <= request.Params.To)
				   .AsQueryable();
				switch (request.Params?.ColumnSort?.ToLower())
				{
					case "title": 
					{
						query = query.OrderBy(d => d.Title);
						break;
					}
					case "level":
					{
						query = query.OrderBy(d => d.Level);
						break;
					}
					case "message":
					{
						query = query.OrderBy(d => d.Message);
						break;
					}
					case "userid":
					{
						query = query.OrderBy(d => d.Userid);
						break;
					}
					default:
					{
						query = query.OrderBy(d => d.Id);
						break;
					}
				}
				return Result<PagedList<Log>>.Success(
					await PagedList<Log>.CreateAsync(query, request.Params.PageNumber,
						request.Params.PageSize)
				);
			}
		}

		public class Query1 : IRequest<Result<PagedList<string>>>
		{
			public LogParams Params { get; set; }
		}
		public class Handler1 : IRequestHandler<Query1, Result<PagedList<string>>>
		{
			private readonly DataContext _context;
			private readonly ILogger<List> _logger;

			public Handler1(DataContext context, ILogger<List> logger)
			{
				_context = context;
				_logger = logger;
			}
			public async Task<Result<PagedList<string>>> Handle(Query1 request, CancellationToken cancellationToken)
			{
				_logger.LogInformation("Runnig get Logs");
				var query = _context.Logs
				   .Where(d => d.Datetimecreation >= request.Params.From && d.Datetimecreation <= request.Params.To)
				   .AsQueryable();
				switch (request.Params?.ColumnSort?.ToLower())
				{
					case "title":
						{
							query = query.OrderBy(d => d.Title);
							break;
						}
					case "level":
						{
							query = query.OrderBy(d => d.Level);
							break;
						}
					case "message":
						{
							query = query.OrderBy(d => d.Message);
							break;
						}
					case "userid":
						{
							query = query.OrderBy(d => d.Userid);
							break;
						}
					default:
						{
							query = query.OrderBy(d => d.Id);
							break;
						}
				}
				switch (request.Params?.ColumnValue?.ToLower())
				{
					case "title":
						{
							return Result<PagedList<string>>.Success(
									await PagedList<string>.CreateAsync(query.Select(x => x.Title), request.Params.PageNumber,
										request.Params.PageSize)); 
						}
					case "level":
						{
							return Result<PagedList<string>>.Success(
									await PagedList<string>.CreateAsync(query.Select(x => x.Level), request.Params.PageNumber,
										request.Params.PageSize));
						}
					case "message":
						{
							return Result<PagedList<string>>.Success(
									await PagedList<string>.CreateAsync(query.Select(x => x.Message), request.Params.PageNumber,
										request.Params.PageSize));
						}
					case "userid":
						{
							return Result<PagedList<string>>.Success(
									await PagedList<string>.CreateAsync(query.Select(x => x.Userid), request.Params.PageNumber,
										request.Params.PageSize));
						}
					default:
						{
							return Result<PagedList<string>>.Success(
									await PagedList<string>.CreateAsync(query.Select(x => x.Title), request.Params.PageNumber,
										request.Params.PageSize));
						}
				}
			}
		}

		public class Query2 : IRequest<Result<List<LogReportDto>>>
		{
			public string userId { get; set; }
			public LogReportParams reportParams { get; set; }
		}
		public class Handler2 : IRequestHandler<Query2, Result<List<LogReportDto>>>
		{
			private readonly DataContext _context;
			private readonly ILogger<List> _logger;
			public Handler2(DataContext context, ILogger<List> logger)
			{
				_context = context;
				_logger = logger;
			}

			public async Task<Result<List<LogReportDto>>> Handle(Query2 request, CancellationToken cancellationToken)
			{
				var query = _context.Logs
				   .Where(d => d.Datetimecreation >= request.reportParams.From && d.Datetimecreation <= request.reportParams.To)
				   .AsQueryable();

				if(!string.IsNullOrEmpty(request.userId))
				{
					query = query.Where(x => x.Userid == request.userId);
				}

				var MyDataIQ = from i in query group i by i.Level into grp select new { key = grp.Key, cnt = grp.Count() };

				var logreport = new List<LogReportDto>();


				foreach (var a in MyDataIQ)
				{
					logreport.Add(new LogReportDto
					{
						Level = a.key,
						Total = a.cnt
					});
				}
				var count = await query.CountAsync();
				logreport.Add(new LogReportDto
				{
					Level = "Total",
					Total = count
				});
				return Result<List<LogReportDto>>.Success(logreport);
			}
		}


	}
}
