using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagment.Data.Entities;

namespace SchoolManagment.Data.Configurations
{
	public class InstructorConfigurations : IEntityTypeConfiguration<Instructor>
	{
		public void Configure(EntityTypeBuilder<Instructor> builder)
		{
			builder.HasOne(x => x.Supervisor)
				.WithMany(x => x.SupervisedInstructors)
				.HasForeignKey(x => x.SupervisorId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}

}
