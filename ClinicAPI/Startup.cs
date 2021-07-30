using ClinicAPI.Models;
using ClinicAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SS5_BackEnd_API.Middlewere;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI
{
	public class Startup
	{
		private IConfiguration configuration;
		public Startup(IConfiguration _configuration)
		{
			configuration = _configuration;
		}
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSession();
			services.AddCors();
			services.AddControllersWithViews();

			var defaultConnection = configuration["ConnectionStrings:DefaultConnection"];
			services.AddDbContext<DatabaseContext>(options => options.UseLazyLoadingProxies().UseSqlServer(defaultConnection));

			services.AddScoped<ScientificEquipmentService, ScientificEquipmentServicelmpl>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseCors(builder => builder
				.AllowAnyHeader()
				.AllowAnyMethod()
				.SetIsOriginAllowed((host) => true)
				.AllowCredentials()
			);
			app.UseMiddleware<corsMiddleware>();
			app.UseRouting();
			app.UseStaticFiles();
			app.UseSession();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();

			});
		}
	}
}
