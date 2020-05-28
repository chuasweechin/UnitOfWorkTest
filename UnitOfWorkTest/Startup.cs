using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UnitOfWorkTest
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			//services.AddDbContext<AppDbContext>(options => {
			//	options.UseNpgsql("Host=localhost;Port=5432;Database=employeeDB;Username=chuasweechin");
			//});

			services.AddDbContextPool<AppDbContext>(options =>
				options.UseSqlServer("Server=localhost,1433\\Catalog=Employee;Database=EmployeeDB;User=sa;Password=Winter2019")
			);

		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();

			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
			});
		}
	}
}
