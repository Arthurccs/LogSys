using LogSys.Domain;
using LogSys.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LogSys.Aplication.Logs
{
	/// <summary>
	/// 
	/// </summary>
	public class List
	{
		public class Query : IRequest<List<Log>> 
		{
		
		}
		public class Handler : IRequestHandler<Query, List<Log>>
		{
			private readonly DataContext _context;

			public Handler(DataContext context)
			{
				_context = context;
			}
			public async Task<List<Log>> Handle(Query request, CancellationToken cancellationToken)
			{
				return await _context.Logs.ToListAsync();
			}
		}
	}
}
