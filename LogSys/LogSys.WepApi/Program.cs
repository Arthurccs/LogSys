using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogSys.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LogSys.WepApi
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			//var host = CreateHostBuilder(args).Build();

			CreateHostBuilder(args).Build().Run();


			//using var scope = host.Services.CreateScope();
			//var services = scope.ServiceProvider;
			//try
			//{
			//	var context = services.GetRequiredService<DataContext>();
			//	await Seed.SeedData(context);

			//}
			//catch (Exception ex)
			//{
			//	var logger = services.GetRequiredService<ILogger<Program>>();
			//	logger.LogError(ex, "An error ocurring during Seed");
			//	throw;
			//}

		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
