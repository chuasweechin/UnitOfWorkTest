using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UnitOfWorkTest.EntityConfiguration
{
  public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
  {
		public void Configure(EntityTypeBuilder<Department> configuration)
		{
			configuration.ToTable("Department");

			//primary key
			configuration.HasKey(e => e.Id);
			configuration.Property(e => e.Id).HasColumnName("Id");
		}
  }
}
