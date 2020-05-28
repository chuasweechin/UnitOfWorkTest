using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UnitOfWorkTest.EntityConfiguration
{
  public class RoleConfiguration : IEntityTypeConfiguration<Role>
  {
		public void Configure(EntityTypeBuilder<Role> configuration)
		{
			configuration.ToTable("Role");

			//primary key
			configuration.HasKey(e => e.Id);
			configuration.Property(e => e.Id).HasColumnName("Id");
		}
  }
}
