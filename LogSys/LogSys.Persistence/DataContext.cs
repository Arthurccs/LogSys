using LogSys.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogSys.Persistence
{
	public class DataContext: DbContext
	{
		public DataContext(DbContextOptions options) : base(options)
		{ 
		}
		public DbSet<Log> Logs { get; set; }

	}
}
