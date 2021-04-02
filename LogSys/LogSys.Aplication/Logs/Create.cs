using LogSys.Domain;
using LogSys.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LogSys.Aplication.Logs
{
	/// <summary>
	/// 4 create log
	/// </summary>
	public class Create
	{
		public class command : IRequest
		{
			public Log Log { get; set; }
		}
		public class Handler : IRequestHandler<command>
		{
			private readonly DataContext _context;

			public Handler(DataContext context)
			{
				_context = context;
			}

			public async Task<Unit> Handle(command request, CancellationToken cancellationToken)
			{
				_context.Logs.Add(request.Log);
				await _context.SaveChangesAsync();
				return Unit.Value;
			}
		}

	}
}
