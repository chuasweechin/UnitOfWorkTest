using Microsoft.EntityFrameworkCore;
using UnitOfWorkTest.EntityConfiguration;

namespace UnitOfWorkTest
{
	public class AppDbContext : DbContext
	{
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Department> Departments { get; set; }
		//public DbSet<Role> Roles { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
			modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
			modelBuilder.ApplyConfiguration(new RoleConfiguration());
		}
	}
}