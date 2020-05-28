using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UnitOfWorkTest.EntityConfiguration
{
  public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
  {
		public void Configure(EntityTypeBuilder<Employee> configuration)
		{
			configuration.ToTable("Employee");

			//primary key
			configuration.HasKey(e => e.Id);
			configuration.Property(e => e.Id).HasColumnName("Id");

			configuration
				.HasMany(e => e.Roles)
				.WithOne()
				.HasForeignKey("FK_EmployeeId");
		}
  }
}
