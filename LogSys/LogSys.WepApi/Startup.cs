using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogSys.Aplication.Logs;
using LogSys.Persistence;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LogSys.WepApi
{
	public class Startup
	{
		private readonly IConfiguration _config;


		public Startup(IConfiguration config)
		{
			_config = config;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddDbContext<DataContext>(opt =>
			{
				opt.UseSqlite(_config.GetConnectionString("DefaultConnection"));
			});
			services.AddMediatR(typeof(List.Handler).Assembly);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env,  DataContext db )
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			//TODO: add security
			//app.UseHttpsRedirection(); 


			db.Database.EnsureCreated();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
