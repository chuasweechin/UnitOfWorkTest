using Microsoft.EntityFrameworkCore;

namespace UnitOfWorkTest
{
	public class AppDbContext : DbContext
	{
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Department> Departments { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

		protected override void OnModelCreating(ModelBuilder modelBuilder) {}
	}
}