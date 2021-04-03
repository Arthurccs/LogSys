using LogSys.Aplication.DTOs;
using LogSys.Domain;
using LogSys.Persistence;
using MediatR;
using System;
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
			public CreateLogDto LogDto { get; set; }
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
				var log = new Log()
				{
					Datetimecreation = DateTime.Now,
					Id = Guid.NewGuid(),
					Level = request.LogDto?.Level,
					Message = request.LogDto?.Message,
					Title = request.LogDto?.Title,
					Userid = request.LogDto?.Userid			
				};
				_context.Logs.Add(log);
				await _context.SaveChangesAsync();
				return Unit.Value;
			}
		}

	}
}
