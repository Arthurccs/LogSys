using LogSys.Domain;
using LogSys.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LogSys.Aplication.Logs
{
	/// <summary>
	/// To get Logs
	/// </summary>
	public class List
	{
		public class Query : IRequest<List<Log>> 
		{
		
		}
		public class Handler : IRequestHandler<Query, List<Log>>
		{
			private readonly DataContext _context;
			private readonly ILogger<List> _logger;

			public Handler(DataContext context, ILogger<List> logger)
			{
				_context = context;
				_logger = logger;
			}
			public async Task<List<Log>> Handle(Query request, CancellationToken cancellationToken)
			{
				_logger.LogInformation("Runnig get Logs");
				return await _context.Logs.ToListAsync();
			}
		}
	}
}
