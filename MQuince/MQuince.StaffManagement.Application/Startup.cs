using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MQuince.StaffManagement.Infrastructure;
using MQuince.StafManagement.Application.Service;
using MQuince.StafManagement.Contracts.Interfaces;

namespace MQuince.StaffManagement.Application
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder();
			dbContextOptionsBuilder.UseMySql(@"server=localhost;user=root;password=root;database=mquince");
			services.AddTransient(typeof(IDoctorService), s => new DoctorService(new UserRepository(dbContextOptionsBuilder)));
			services.AddTransient(typeof(ISpecializationService), s => new SpecializationService(new SpecializationRepository(dbContextOptionsBuilder)));
			services.AddTransient(typeof(IWorkTimeService), s => new WorkTimeService(new WorkTimeRepository(dbContextOptionsBuilder)));

			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
